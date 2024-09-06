namespace Trabalho_Final_Prog2
{
    partial class RelataContratos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.imobiliariaDBDataSet = new Trabalho_Final_Prog2.ImobiliariaDBDataSet();
            this.contratoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contratoTableAdapter = new Trabalho_Final_Prog2.ImobiliariaDBDataSetTableAdapters.ContratoTableAdapter();
            this.contratoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imobiliariaDBDataSet1 = new Trabalho_Final_Prog2.ImobiliariaDBDataSet1();
            this.contratoBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.contratoTableAdapter1 = new Trabalho_Final_Prog2.ImobiliariaDBDataSet1TableAdapters.ContratoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.imobiliariaDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imobiliariaDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.contratoBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Trabalho_Final_Prog2.RelatorioContratos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, -2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1002, 566);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // imobiliariaDBDataSet
            // 
            this.imobiliariaDBDataSet.DataSetName = "ImobiliariaDBDataSet";
            this.imobiliariaDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contratoBindingSource
            // 
            this.contratoBindingSource.DataMember = "Contrato";
            this.contratoBindingSource.DataSource = this.imobiliariaDBDataSet;
            // 
            // contratoTableAdapter
            // 
            this.contratoTableAdapter.ClearBeforeFill = true;
            // 
            // contratoBindingSource1
            // 
            this.contratoBindingSource1.DataMember = "Contrato";
            this.contratoBindingSource1.DataSource = this.imobiliariaDBDataSet;
            // 
            // ClienteBindingSource
            // 
            this.ClienteBindingSource.DataMember = "Cliente";
            this.ClienteBindingSource.DataSource = this.imobiliariaDBDataSet;
            // 
            // imobiliariaDBDataSet1
            // 
            this.imobiliariaDBDataSet1.DataSetName = "ImobiliariaDBDataSet1";
            this.imobiliariaDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contratoBindingSource2
            // 
            this.contratoBindingSource2.DataMember = "Contrato";
            this.contratoBindingSource2.DataSource = this.imobiliariaDBDataSet1;
            // 
            // contratoTableAdapter1
            // 
            this.contratoTableAdapter1.ClearBeforeFill = true;
            // 
            // RelataContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 567);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelataContratos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Contratos";
            this.Load += new System.EventHandler(this.RelataContratos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imobiliariaDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imobiliariaDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ImobiliariaDBDataSet imobiliariaDBDataSet;
        private System.Windows.Forms.BindingSource contratoBindingSource;
        private ImobiliariaDBDataSetTableAdapters.ContratoTableAdapter contratoTableAdapter;
        private System.Windows.Forms.BindingSource contratoBindingSource1;
        private System.Windows.Forms.BindingSource ClienteBindingSource;
        private ImobiliariaDBDataSet1 imobiliariaDBDataSet1;
        private System.Windows.Forms.BindingSource contratoBindingSource2;
        private ImobiliariaDBDataSet1TableAdapters.ContratoTableAdapter contratoTableAdapter1;
    }
}