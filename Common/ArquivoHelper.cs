using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace FrameVioti.Common
{
    public class ArquivoHelper
    {
        public string LerArquivo(string caminhoArquivo)
        {
            try
            {
                return File.ReadAllText(caminhoArquivo);
            }
            catch (IOException ex)
            {
                // Tratar exceção ou relançá-la
                throw;
            }
        }

        public void EnviarArquivo(string caminhoArquivo, string destino)
        {
            try
            {
                // Carregar o arquivo original
                var workbookOriginal = new HSSFWorkbook();

                using (FileStream fileStream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read))
                {
                    workbookOriginal = new HSSFWorkbook(fileStream);
                }

                // Criar um novo arquivo no formato .xls
                var workbookDestino = new HSSFWorkbook();

                // Copiar as planilhas do arquivo original para o novo arquivo
                for (int i = 0; i < workbookOriginal.NumberOfSheets; i++)
                {
                    ISheet sheetOriginal = workbookOriginal.GetSheetAt(i);
                    ISheet sheetDestino = workbookDestino.CreateSheet(sheetOriginal.SheetName);

                    for (int j = 0; j <= sheetOriginal.LastRowNum; j++)
                    {
                        IRow rowOriginal = sheetOriginal.GetRow(j);
                        IRow rowDestino = sheetDestino.CreateRow(j);

                        for (int k = 0; k < rowOriginal.LastCellNum; k++)
                        {
                            ICell cellOriginal = rowOriginal.GetCell(k);

                            if (cellOriginal != null)
                            {
                                ICell cellDestino = rowDestino.CreateCell(k, cellOriginal.CellType);

                                switch (cellOriginal.CellType)
                                {
                                    case CellType.Boolean:
                                        cellDestino.SetCellValue(cellOriginal.BooleanCellValue);
                                        break;
                                    case CellType.Numeric:
                                        cellDestino.SetCellValue(cellOriginal.NumericCellValue);
                                        break;
                                    case CellType.String:
                                        cellDestino.SetCellValue(cellOriginal.StringCellValue);
                                        break;
                                    case CellType.Formula:
                                        cellDestino.CellFormula = cellOriginal.CellFormula;
                                        break;
                                        // Adicione os demais tipos de células, se necessário
                                }
                            }
                        }
                    }
                }

                // Salvar o novo arquivo
                using (FileStream fileStream = new FileStream(destino, FileMode.Create, FileAccess.Write))
                {
                    workbookDestino.Write(fileStream);
                }
            }
            catch (IOException ex)
            {
                // Tratar exceção ou relançá-la
                throw;
            }
        }
    }
}