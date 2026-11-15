using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyBanVeMayBay.DAL
{
    /// <summary>
    /// Các hàm chạy câu lệnh SQL / stored procedure dùng chung cho mọi lớp DAL.
    /// Kết nối được lấy từ KetNoiCSDL.
    /// </summary>
    public static class DataProvider
    {
        public static SqlParameter P(string ten, object giaTri)
        {
            return new SqlParameter(ten, giaTri ?? DBNull.Value);
        }

        public static DataTable ExecuteQuery(string sql, params SqlParameter[] thamSo)
        {
            return Fill(sql, CommandType.Text, thamSo);
        }

        public static DataTable ExecuteProc(string tenProc, params SqlParameter[] thamSo)
        {
            return Fill(tenProc, CommandType.StoredProcedure, thamSo);
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] thamSo)
        {
            using (var cn = KetNoiCSDL.TaoKetNoi())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(thamSo);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] thamSo)
        {
            using (var cn = KetNoiCSDL.TaoKetNoi())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(thamSo);
                cn.Open();
                object kq = cmd.ExecuteScalar();
                return kq == DBNull.Value ? null : kq;
            }
        }

        // =========================================================
        // Chạy nhiều lệnh trong cùng một giao dịch: lỗi ở bất kỳ bước nào thì hoàn tác tất cả.
        // =========================================================
        public static T ChayTrongGiaoDich<T>(Func<SqlConnection, SqlTransaction, T> congViec)
        {
            using (var cn = KetNoiCSDL.TaoKetNoi())
            {
                cn.Open();
                using (var tx = cn.BeginTransaction())
                {
                    try
                    {
                        T kq = congViec(cn, tx);
                        tx.Commit();
                        return kq;
                    }
                    catch
                    {
                        // Thủ tục lỗi có thể đã tự ROLLBACK phía máy chủ; khi đó Rollback ở đây không còn gì để làm.
                        try { tx.Rollback(); } catch (InvalidOperationException) { }
                        throw;
                    }
                }
            }
        }

        public static DataTable ExecuteProc(SqlConnection cn, SqlTransaction tx, string tenProc, params SqlParameter[] thamSo)
        {
            using (var cmd = new SqlCommand(tenProc, cn, tx) { CommandType = CommandType.StoredProcedure })
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(thamSo);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int ExecuteNonQuery(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] thamSo)
        {
            using (var cmd = new SqlCommand(sql, cn, tx))
            {
                cmd.Parameters.AddRange(thamSo);
                return cmd.ExecuteNonQuery();
            }
        }

        private static DataTable Fill(string text, CommandType loai, SqlParameter[] thamSo)
        {
            using (var cn = KetNoiCSDL.TaoKetNoi())
            using (var cmd = new SqlCommand(text, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = loai;
                cmd.Parameters.AddRange(thamSo);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
