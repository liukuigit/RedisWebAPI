using System;
using System.Collections.Generic;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XWPF.UserModel;
using NPOI.OpenXmlFormats.Wordprocessing;
using System.IO;
using System.Runtime.Remoting.Contexts;


namespace BQ_APILogic.Helper
{
    public class WordConverterNpoi
    {
        public string Convert(string filePath, string newfilePath, string documentNo)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                XWPFDocument doc = new XWPFDocument(stream);


                FileStream out1 = new FileStream(newfilePath, FileMode.Create);
                doc.Write(out1);
                out1.Close();
            }



            //using (FileStream fs = File.OpenRead(filePath))
            //{
            //    try
            //    {
            //        // FileStream stream = File.OpenRead(filePath);

            //        XWPFDocument m_Docx = new XWPFDocument(fs);


            //        //页面设置
            //        //A4:W=11906,h=16838
            //        //CT_SectPr m_SectPr = m_Docx.Document.body.AddNewSectPr();
            //        m_Docx.Document.body.sectPr = new CT_SectPr();
            //        CT_SectPr m_SectPr = m_Docx.Document.body.sectPr;
            //        //页面设置A4横向
            //        //m_SectPr.pgSz.w = (ulong)16838;
            //        //m_SectPr.pgSz.h = (ulong)11906;

            //        //创建页脚
            //        CT_Ftr m_ftr = new CT_Ftr();
            //        m_ftr.AddNewP().AddNewR().AddNewT().Value = "fff";//页脚内容
            //        //创建页脚关系（footern.xml）
            //        XWPFRelation Frelation = XWPFRelation.FOOTER;
            //        XWPFFooter m_f = (XWPFFooter)m_Docx.CreateRelationship(Frelation, XWPFFactory.GetInstance(), m_Docx.FooterList.Count + 1);
            //        //设置页脚
            //        m_f.SetHeaderFooter(m_ftr);
            //        CT_HdrFtrRef m_HdrFtr = m_SectPr.AddNewFooterReference();
            //        m_HdrFtr.type = ST_HdrFtr.@default;
            //        m_HdrFtr.id = m_f.GetPackageRelationship().Id;

            //        //创建页眉
            //        CT_Hdr m_Hdr = new CT_Hdr();
            //        m_Hdr.AddNewP().AddNewR().AddNewT().Value = documentNo;//页眉内容
            //        //创建页眉关系（headern.xml）
            //        XWPFRelation Hrelation = XWPFRelation.HEADER;
            //        XWPFHeader m_h = (XWPFHeader)m_Docx.CreateRelationship(Hrelation, XWPFFactory.GetInstance(), m_Docx.HeaderList.Count + 1);
            //        //设置页眉
            //        m_h.SetHeaderFooter(m_Hdr);
            //        m_HdrFtr = m_SectPr.AddNewHeaderReference();
            //        m_HdrFtr.type = ST_HdrFtr.@default;
            //        m_HdrFtr.id = m_h.GetPackageRelationship().Id;


            //        FileStream out1 = new FileStream(newfilePath, FileMode.Create);
            //        m_Docx.Write(out1);
            //        out1.Close();

            //    }
            //    catch (Exception ex)
            //    { 
                    
            //    }
            //}
            return newfilePath;

        }
    }
}
