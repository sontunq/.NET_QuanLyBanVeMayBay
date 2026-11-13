using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyBanVeMayBay.DAL
{
    public static class DataProvider
    {
        public const string TenCSDL = "QuanLyBanVeMayBay2";

        public static string ChuoiKetNoi { get; set; } = "";

        public static string TaoChuoiKetNoi(string mayChu)
        {
            string s = (mayChu ?? "").Trim();
            if (s.Contains("=")) return s;
            if (s.Length == 0) s = ".";
            return $"Server={s};Database={TenCSDL};Integrated Security=True;TrustServerCertificate=True;Encrypt=False";
        }

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
            using (var cn = new SqlConnection(ChuoiKetNoi))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(thamSo);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] thamSo)
        {
            using (var cn = new SqlConnection(ChuoiKetNoi))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(thamSo);
                cn.Open();
                object kq = cmd.ExecuteScalar();
                return kq == DBNull.Value ? null : kq;
            }
        }

        private static DataTable Fill(string text, CommandType loai, SqlParameter[] thamSo)
        {
            using (var cn = new SqlConnection(ChuoiKetNoi))
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
