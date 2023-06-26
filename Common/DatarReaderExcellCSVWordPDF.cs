using System;
using System.Collections.Generic;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using NPOI;
using System.Text;
using Path = System.IO.Path;

namespace FrameVioti.Common
{
    public class DatarReaderExcellCSVWordPDF
    {
        private string nomeArquivo;
        private XSSFWorkbook wb;
        private XSSFSheet planilha;
        private List<string[]> linhasCSV;
        private WordprocessingDocument documentoWord;
        private iTextSharp.text.pdf.PdfReader documentoPDF;

        public DatarReaderExcellCSVWordPDF(string nomeArquivo, int indicePlanilha)
        {
            try
            {
                this.nomeArquivo = ObtemCaminhoDoArquivo(nomeArquivo);
                if (nomeArquivo.EndsWith(".xlsx"))
                    this.AbrePlanilhaExcel(indicePlanilha);
                else if (nomeArquivo.EndsWith(".csv"))
                    this.LerArquivoCSV();
                else if (nomeArquivo.EndsWith(".docx"))
                    this.AbreDocumentoWord();
                else if (nomeArquivo.EndsWith(".pdf"))
                    this.AbreDocumentoPDF();
            }
            catch (Exception e)
            {
                // Trate o erro de alguma forma adequada
            }
        }

        public DatarReaderExcellCSVWordPDF(string nomeArquivo, string nomeAba)
        {
            this.nomeArquivo = ObtemCaminhoDoArquivo(nomeArquivo);
            if (nomeArquivo.EndsWith(".xlsx"))
                this.AbrePlanilhaExcel(nomeAba);
            else if (nomeArquivo.EndsWith(".csv"))
                this.LerArquivoCSV();
            else if (nomeArquivo.EndsWith(".docx"))
                this.AbreDocumentoWord();
            else if (nomeArquivo.EndsWith(".pdf"))
                this.AbreDocumentoPDF();
        }

        private void AbrePlanilhaExcel(int indicePlanilha)
        {
            try
            {
                this.wb = new XSSFWorkbook(new FileStream(this.ObtemArquivoExcel(), FileMode.Open, FileAccess.ReadWrite));
            }
            catch (IOException ex)
            {
                string message = "Erro ao abrir a pasta de Excel em '" + this.ObtemArquivoExcel() + "' ...";
                throw new IOException(message, ex);
            }

            this.planilha = (XSSFSheet)this.GetWorkBook().GetSheetAt(indicePlanilha);
        }

        private void AbrePlanilhaExcel(string nomePlanilha)
        {
            try
            {
                this.wb = new XSSFWorkbook(new FileStream(this.ObtemArquivoExcel(), FileMode.Open, FileAccess.ReadWrite));
            }
            catch (IOException ex)
            {
                string message = "Erro ao abrir a pasta de Excel em '" + this.ObtemArquivoExcel() + "' ...";
                throw new IOException(message, ex);
            }

            this.planilha = (XSSFSheet)this.GetWorkBook().GetSheet(nomePlanilha);
            if (this.planilha == null)
            {
                string message = "Não foi possível abrir a planilha de nome '" + nomePlanilha + "' ...";
                throw new IOException(message);
            }
        }

        private string ObtemArquivoExcel()
        {
            return this.nomeArquivo;
        }

        private string ObtemCaminhoDoArquivo(string nomeArquivo)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "MassaDeDadosExcel", nomeArquivo);
        }

        private XSSFWorkbook GetWorkBook()
        {
            return this.wb;
        }

        private void LerArquivoCSV()
        {
            using (var reader = new StreamReader(this.nomeArquivo))
            {
                this.linhasCSV = new List<string[]>();
                while (!reader.EndOfStream)
                {
                    var linha = reader.ReadLine();
                    var valores = linha.Split(',');
                    this.linhasCSV.Add(valores);
                }
            }
        }

        private void AbreDocumentoWord()
        {
            this.documentoWord = WordprocessingDocument.Open(this.nomeArquivo, true);
        }

        private void AbreDocumentoPDF()
        {
            this.documentoPDF = new iTextSharp.text.pdf.PdfReader(this.nomeArquivo);
        }

        public string GetTextoSimplesCelula(int linha, int coluna)
        {
            if (this.planilha != null)
                return this.planilha.GetRow(linha).GetCell(coluna).StringCellValue;
            else if (this.linhasCSV != null)
                return this.linhasCSV[linha][coluna];
            else if (this.documentoWord != null)
            {
                var corpoDocumento = this.documentoWord.MainDocumentPart.Document.Body;
                var tabela = corpoDocumento.Elements<DocumentFormat.OpenXml.Drawing.Table>().FirstOrDefault();
                var celula = tabela.Elements<DocumentFormat.OpenXml.Drawing.TableRow>().ElementAt(linha).Elements<TableCell>().ElementAt(coluna);
                return celula.InnerText;
            }
            else if (this.documentoPDF != null)
            {
                StringBuilder content = new StringBuilder();
                var strategy = new SimpleTextExtractionStrategy();

                for (int page = 1; page <= this.documentoPDF.NumberOfPages; page++)
                {
                    var pageText = PdfTextExtractor.GetTextFromPage(this.documentoPDF, page, strategy);
                    content.Append(pageText);
                }

                return content.ToString();
            }

            return string.Empty;
        }

        // Restante dos métodos...
    }
}
