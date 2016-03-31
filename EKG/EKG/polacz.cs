﻿using System.Windows.Forms;
using System;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace EKG
{
    //Klasa do nawiązania połączenia z bazą danych. 
    class polacz
    {
        public DataSet fire_polacz(string zapytanie)
        {

            //obsługa połączenia z bazą danych
            string cselx = "User=SYSDBA;" +
                           "Password=masterkey;" +
                           "Database=baza;" +
                           "DataSource=localhost;" +
                           "Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0";

            FbConnection fb_conn = new FbConnection(cselx);

            //DataSet dt = null;
            fb_conn.Open();

            FbCommand fb_comm = new FbCommand();
            FbTransaction fb_trans = fb_conn.BeginTransaction();
            fb_comm.Connection = fb_conn;
            fb_comm.Transaction = fb_trans;

            fb_comm.CommandText = zapytanie;

            FbDataAdapter adapter = new FbDataAdapter(fb_comm);
            DataSet dt = new DataSet();
            adapter.Fill(dt);

            fb_conn.Close();
            return dt;
        }

        public void fire_wyslij(string zapytanie)
        {
            string cselx = "User=SYSDBA;" +
                           "Password=masterkey;" +
                           "Database=baza;" +
                           "DataSource=localhost;" +
                           "Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0";

            FbConnection fb_conn = new FbConnection(cselx);

            fb_conn.Open();

            FbCommand fb_comm = new FbCommand();
            FbTransaction fb_trans = fb_conn.BeginTransaction();
            fb_comm.Connection = fb_conn;
            fb_comm.Transaction = fb_trans;

            fb_comm.CommandText = zapytanie;

            FbDataAdapter adapter = new FbDataAdapter(fb_comm);
            fb_conn.Close();
        }
    }
}
