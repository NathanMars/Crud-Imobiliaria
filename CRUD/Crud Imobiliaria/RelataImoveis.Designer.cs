namespace Trabalho_Final_Prog2
{
    partial class RelataImoveis
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
            this.imobiliariaDBDataSet = new Trabalho_Final_Prog2.ImobiliariaDBDataSet();
            this.contratoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contratoTableAdapter = new Trabalho_Final_Prog2.ImobiliariaDBDataSetTableAdapters.ContratoTableAdapter();
            this.imovelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imovelTableAdapter = new Trabalho_Final_Prog2.ImobiliariaDBDataSetTableAdapters.ImovelTableAdapter();
            this.imobiliariaDBDataSet2 = new Trabalho_Final_Prog2.ImobiliariaDBDataSet2();
            this.imovelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.imovelTableAdapter1 = new Trabalho_Final_Prog2.ImobiliariaDBDataSet2TableAdapters.ImovelTableAdapter();
            this.imovelBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.imobiliariaDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imovelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imobiliariaDBDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imovelBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imovelBindingSource2)).BeginInit();
            this.SuspendLayout();
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
            // imovelBindingSource
            // 
            this.imovelBindingSource.DataMember = "Imovel";
            this.imovelBindingSource.DataSource = this.imobiliariaDBDataSet;
            // 
            // imovelTableAdapter
            // 
            this.imovelTableAdapter.ClearBeforeFill = true;
            // 
            // imobiliariaDBDataSet2
            // 
            this.imobiliariaDBDataSet2.DataSetName = "ImobiliariaDBDataSet2";
            this.imobiliariaDBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // imovelBindingSource1
            // 
            this.imovelBindingSource1.DataMember = "Imovel";
            this.imovelBindingSource1.DataSource = this.imobiliariaDBDataSet2;
            // 
            // imovelTableAdapter1
            // 
            this.imovelTableAdapter1.ClearBeforeFill = true;
            // 
            // imovelBindingSource2
            // 
            this.imovelBindingSource2.DataMember = "Imovel";
            this.imovelBindingSource2.DataSource = this.imobiliariaDBDataSet2;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.imovelBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Trabalho_Final_Prog2.RelatorioImoveis.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(7, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(987, 560);
            this.reportViewer1.TabIndex = 0;
            // 
            // RelataImoveis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 567);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RelataImoveis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Imóveis";
            this.Load += new System.EventHandler(this.RelataImoveis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imobiliariaDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contratoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imovelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imobiliariaDBDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imovelBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imovelBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ImobiliariaDBDataSet imobiliariaDBDataSet;
        private System.Windows.Forms.BindingSource contratoBindingSource;
        private ImobiliariaDBDataSetTableAdapters.ContratoTableAdapter contratoTableAdapter;
        private System.Windows.Forms.BindingSource imovelBindingSource;
        private ImobiliariaDBDataSetTableAdapters.ImovelTableAdapter imovelTableAdapter;
        private ImobiliariaDBDataSet2 imobiliariaDBDataSet2;
        private System.Windows.Forms.BindingSource imovelBindingSource1;
        private ImobiliariaDBDataSet2TableAdapters.ImovelTableAdapter imovelTableAdapter1;
        private System.Windows.Forms.BindingSource imovelBindingSource2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}