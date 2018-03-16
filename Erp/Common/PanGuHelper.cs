using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanGu.Match;
using PanGu;
using Lucene.Net.Index;
using System.Reflection;
using Lucene.Net.Documents;
using Lucene.Net.Analysis;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;

//陈盼盼----------暂未使用，待研究
namespace Maticsoft.Common
{
    public class PanGuHelper
    {
        private PanGuHelper() { }

        #region 实例
        private Lucene.Net.Store.Directory _directory_luce = null;
        public Lucene.Net.Store.Directory directory_luce
        {
            get
            {
                if (_directory_luce == null) _directory_luce = Lucene.Net.Store.FSDirectory.Open(directory);
                return _directory_luce;
            }
        }
        private System.IO.DirectoryInfo _directory = null;
        public System.IO.DirectoryInfo directory
        {
            get
            {
                if (_directory == null)
                {
                    string dirPath = AppDomain.CurrentDomain.BaseDirectory + "SearchIndex";
                    if (System.IO.Directory.Exists(dirPath) == false) _directory = System.IO.Directory.CreateDirectory(dirPath);
                    else _directory = new System.IO.DirectoryInfo(dirPath);
                }
                return _directory;
            }
        }

        private Analyzer _analyzer = null;
        public Analyzer analyzer
        {
            get
            {
                //if (_analyzer == null)
                {
                    _analyzer = new Lucene.Net.Analysis.PanGu.PanGuAnalyzer();//
                    //_analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
                }
                return _analyzer;
            }
        }

        private Lucene.Net.Util.Version version = new Lucene.Net.Util.Version();

        #endregion

        #region 单一实例
        private static PanGuHelper _instance = null;
        /// <summary>
        /// 单一实例
        /// </summary>
        public static PanGuHelper instance
        {
            get
            {
                if (_instance == null) _instance = new PanGuHelper();
                return _instance;
            }
        }
        #endregion

        #region 对要搜索的词分词

        /// <summary>
        /// 对要搜索的词分词-----------陈盼盼
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="ktTokenizer"></param>
        /// <returns></returns>
        public static string GetKeyWordsSplitBySpace(string keywords)
        {
            MatchOptions options = new MatchOptions();//分词设置
            options.ChineseNameIdentify = true;//中文人名识别
            options.FrequencyFirst = true;//词频优先
            //options.ForceSingleWord = true;//强制一元分词
            options.OutputSimplifiedTraditional = true;//同时输出简体和繁体
            StringBuilder result = new StringBuilder();
            Segment segment = new Segment();
            ICollection<WordInfo> words = segment.DoSegment(keywords, options);//ktTokenizer.SegmentToWordInfos(keywords);
            foreach (WordInfo word in words)
            {
                if (word == null)
                {
                    continue;
                }
                result.AppendFormat("{0}^{1}.0 ", word.Word, (int)Math.Pow(3, word.Rank));
            }
            return result.ToString().Trim();
        }

        #endregion

        #region 创建索引
        /// <summary>
        /// 创建索引
        /// </summary>
        /// <param name="datalist"></param>
        /// <returns></returns>
        public bool CreateIndex<T>(IList<T> datalist)
        {
            IndexWriter writer = null;
            try
            {
                writer = new IndexWriter(directory_luce, analyzer, false, IndexWriter.MaxFieldLength.LIMITED);//false表示追加（true表示删除之前的重新写入）
            }
            catch
            {
                writer = new IndexWriter(directory_luce, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);//false表示追加（true表示删除之前的重新写入）
            }
            foreach (T data in datalist)
            {
                CreateIndex(writer, data);
            }
            writer.Optimize();
            writer.Dispose();
            return true;
        }

        public bool CreateIndex<T>(IndexWriter writer, T data)
        {
            try
            {

                if (data == null) return false;
                Document doc = new Document();
                Type type = data.GetType();//assembly.GetType("Reflect_test.PurchaseOrderHeadManageModel", true, true); //命名空间名称 + 类名    

                //创建类的实例    
                //object obj = Activator.CreateInstance(type, true);  
                //获取公共属性    
                PropertyInfo[] Propertys = type.GetProperties();
                for (int i = 0; i < Propertys.Length; i++)
                {
                    //Propertys[i].SetValue(Propertys[i], i, null); //设置值
                    PropertyInfo pi = Propertys[i];
                    string name = pi.Name;
                    object objval = pi.GetValue(data, null);
                    string value = objval == null ? "" : objval.ToString(); //值
                    if (name == "id")//id在写入索引时必是不分词，否则是模糊搜索和删除，会出现混乱
                    {
                        doc.Add(new Field(name, value, Field.Store.YES, Field.Index.NOT_ANALYZED));//id不分词
                    }
                    else
                    {
                        doc.Add(new Field(name, value, Field.Store.YES, Field.Index.ANALYZED));
                    }
                }
                writer.AddDocument(doc);
            }
            catch (System.IO.FileNotFoundException fnfe)
            {
                throw fnfe;
            }
            return true;
        }
        #endregion

        //#region 查询数据
        ///// <summary>
        ///// 查询数据
        ///// </summary>
        ///// <param name="keyword"></param>
        ///// <returns></returns>
        //public List<T> Search<T>(string keyword, string[] fileds)
        //{

        //    //string[] fileds = { "title", "content", "flag" };//查询字段
        //    //Stopwatch st = new Stopwatch();
        //    //st.Start();
        //    keyword = GetKeyWordsSplitBySpace(keyword);//分词
        //    QueryParser parser = null;// new QueryParser(Lucene.Net.Util.Version.LUCENE_30, field, analyzer);//一个字段查询
        //    parser = new MultiFieldQueryParser(version, fileds, analyzer);//多个字段查询
        //    Query query = parser.Parse(keyword);
        //    int n = 1000;
        //    IndexSearcher searcher = new IndexSearcher(directory_luce, true);//true-表示只读
        //    TopDocs docs = searcher.Search(query, (Filter)null, n) ;

        //    if (docs == null || docs.TotalHits == 0)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        IList<T> list = new List<T>();
        //        int counter = 1;
        //        foreach (ScoreDoc sd in docs.ScoreDocs)//遍历搜索到的结果
        //        {
        //            try
        //            {
        //                Document doc = searcher.Doc(sd.Doc);
        //                string id = doc.Get("id");
        //                string title = doc.Get("title");
        //                string content = doc.Get("content");
        //                string flag = doc.Get("flag");
        //                string createdate = doc.Get("createtime");

        //                PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter = new PanGu.HighLight.SimpleHTMLFormatter("<font color=\"red\">", "</font>");
        //                PanGu.HighLight.Highlighter highlighter = new PanGu.HighLight.Highlighter(simpleHTMLFormatter, new PanGu.Segment());
        //                highlighter.FragmentSize = 50;
        //                string contenthighlighter = highlighter.GetBestFragment(keyword, content);
        //                if (contenthighlighter != "") content = contenthighlighter;
        //                string titlehighlight = highlighter.GetBestFragment(keyword, title);
        //                if (titlehighlight != "") title = titlehighlight;
        //                string flaghighlight = highlighter.GetBestFragment(keyword, flag);
        //                if (flaghighlight != "") flag = flaghighlight;
        //                list.Add(new T(id, title, content, flag, createdate));
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //            }
        //            counter++;
        //        }
        //        return list;
        //    }
        //    //st.Stop();
        //    //Response.Write("查询时间：" + st.ElapsedMilliseconds + " 毫秒<br/>");

        //}
        //#endregion
    }
}
