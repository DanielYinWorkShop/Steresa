﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace St.Teresa_LIS_2019
{
    public partial class Form_SelectPatient : Form
    {
        public Boolean mergeSlavee;
        private DataTable dt;
        private DataSet patientDataSet = new DataSet();

        public delegate void PatientSelectedMore(string idStr);
        public PatientSelectedMore OnPatientSelectedMore;

        public Form_SelectPatient()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            //OnPatientSelectedMore(null);
            this.Close();
        }

        private void Form_SelectPatient_Load(object sender, EventArgs e)
        {
            dismerge();
            mergeSlavee = false;
            if (Form_PatientFileMaintenancecs.merge)
            {
                merging();
            }
            loadDataGridViewDate();
            dataGridViewFormat();
        }
        private void loadDataGridViewDate()
        {
            string sql = "SELECT patient,cname,hkid,seq,sex,birth,age,id FROM [PATIENT]";
            DBConn.fetchDataIntoDataSetSelectOnly(sql, patientDataSet, "patient");

            DataTable dt = new DataTable();
            dt.Columns.Add("Select",typeof(bool));
            dt.Columns.Add("Patient's Name");
            dt.Columns.Add("Chinese Name");
            dt.Columns.Add("HKid");
            dt.Columns.Add("No.");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Birth");
            dt.Columns.Add("Age");
            dt.Columns.Add("Id");

            foreach (DataRow mDr in patientDataSet.Tables["patient"].Rows)
            {
                dt.Rows.Add( new object[] { "false", mDr["patient"], mDr["cname"], mDr["hkid"], mDr["seq"], mDr["sex"], mDr["birth"], mDr["age"], mDr["id"] });
            }

            dataGridView1.DataSource = dt;
        }
        private void dataGridViewFormat()
        {
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 30;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 190;
            column1.ReadOnly = true;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 145;
            column2.ReadOnly = true;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 130;
            column3.ReadOnly = true;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 30;
            column4.ReadOnly = true;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 30;
            column5.ReadOnly = true;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 130;
            column6.ReadOnly = true;
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 60;
            column7.ReadOnly = true;
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Width = 1;
            column8.ReadOnly = true;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;

        }

        private void merging()
        {
            label_merge.Visible = true;
            label_merge.ForeColor = Color.Red;
            label_merge.Text = "Select merge Master patient";

        }
        private void dismerge()
        {
            label_merge.Visible = false;
        }

        private void mergeSlave()
        {
            label_merge.Text = "Select merge Slave patient";
            label_merge.ForeColor = Color.Green;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            string idStr = "";
            for (int i=0; i < dataGridView1.Rows.Count; i++)
            {
                if (bool.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) == true)
                {
                    if (dataGridView1.Rows[i].Cells[8].Value.ToString() != "")
                    {
                        if (idStr == "")
                        {
                            idStr += dataGridView1.Rows[i].Cells[8].Value.ToString();
                        }
                        else
                        {
                            idStr += "," + dataGridView1.Rows[i].Cells[8].Value.ToString();
                        }

                    }
                }
            }
            OnPatientSelectedMore(idStr);
            this.Close();
        }

        private void textBox_Serch_Patient_TextChanged(object sender, EventArgs e)
        {
            string sql = string.Format("SELECT patient,cname,hkid,seq,sex,birth,age,id FROM [PATIENT] WHERE PATIENT LIKE '%{0}%' OR CNAME LIKE '%{0}%'", textBox_Serch_Patient.Text.Trim());
            DBConn.fetchDataIntoDataSetSelectOnly(sql, patientDataSet, "patient");

            DataTable dt = new DataTable();
            dt.Columns.Add("Select", typeof(bool));
            dt.Columns.Add("Patient's Name");
            dt.Columns.Add("Chinese Name");
            dt.Columns.Add("HKid");
            dt.Columns.Add("No.");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Birth");
            dt.Columns.Add("Age");
            dt.Columns.Add("Id");

            foreach (DataRow mDr in patientDataSet.Tables["patient"].Rows)
            {
                dt.Rows.Add(new object[] { "false", mDr["patient"], mDr["cname"], mDr["hkid"], mDr["seq"], mDr["sex"], mDr["birth"], mDr["age"], mDr["id"] });
            }

            dataGridView1.DataSource = dt;
        }
    }
}
