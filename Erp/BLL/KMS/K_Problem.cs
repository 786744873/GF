using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using System.Reflection;
using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Store;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using PanGu.Match;
using System.Text;
using PanGu;
namespace CommonService.BLL.KMS
{
    /// <summary>
    /// 问题表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
    public partial class K_Problem
    {
        private readonly CommonService.DAL.KMS.K_Problem dal = new CommonService.DAL.KMS.K_Problem();
        private readonly CommonService.BLL.KMS.K_Comments commentBll = new CommonService.BLL.KMS.K_Comments();
        private readonly CommonService.DAL.KMS.K_Comments commentDal = new CommonService.DAL.KMS.K_Comments();
        private readonly CommonService.DAL.C_Messages messageDal = new CommonService.DAL.C_Messages();
        public K_Problem()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int K_Problem_id)
        {
            return dal.Exists(K_Problem_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Problem model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_Problem model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid K_Problem_code)
        {
            dal.Delete(K_Problem_code);
            //commentDal.DeleteByFkCode(K_Problem_code);//删除问题回答
            List<CommonService.Model.KMS.K_Comments> comments = commentBll.GetCommentsListByCode(K_Problem_code);
            foreach (CommonService.Model.KMS.K_Comments comment in comments)
            {
                commentDal.Delete(comment.K_Comments_code.Value);//删除问题回答
                messageDal.DeleteByLink(comment.K_Comments_code.Value);//删除关联消息
                deleteChild(comment.K_Comments_code.Value);//删除问题子级回答
            }
            return true;
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="K_Problem_idlist"></param>
        /// <returns></returns>
        public bool DeleteList(string K_Problem_idlist)
        {
            K_Problem_idlist = "'" + K_Problem_idlist + "'";
            bool result = dal.DeleteList(K_Problem_idlist);
            if (result)
            {
                string[] code = K_Problem_idlist.Split(',');
                foreach (string item in code)
                {
                    string resCode = item.Substring(1, item.Length - 2);
                    List<CommonService.Model.KMS.K_Comments> comments = commentBll.GetCommentsListByCode(new Guid(resCode));
                    foreach (CommonService.Model.KMS.K_Comments comment in comments)
                    {
                        commentDal.Delete(comment.K_Comments_code.Value); ;//删除问题回答
                        messageDal.DeleteByLink(comment.K_Comments_code.Value);//删除关联消息
                        deleteChild(comment.K_Comments_code.Value);//删除问题子级回答
                    }
                }
            }
            return result;
        }
        private void deleteChild(Guid parentCode)
        {
            List<CommonService.Model.KMS.K_Comments> comments = commentBll.GetListByParent(parentCode);//获取子级数据列表
            foreach (CommonService.Model.KMS.K_Comments comment in comments)
            {
                commentDal.Delete(comment.K_Comments_code.Value);
                messageDal.DeleteByLink(comment.K_Comments_code.Value);//删除关联消息
                deleteChild(comment.K_Comments_code.Value);//删除问题子级回答
            }
        }
        /// <summary>
        /// 问题审核
        /// </summary>
        /// <param name="problemCode"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool ProblemAudit(Guid problemCode, int state)
        {
            return dal.ProblemAudit(problemCode, state);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Problem GetModel(int K_Problem_id)
        {

            return dal.GetModel(K_Problem_id);
        }
        /// <summary>
        /// 根据code集合获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Problem> GetListByCodeList(string codeList)
        {
            return DataTableToList(dal.GetListByCodeList(codeList).Tables[0]);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Problem GetModel(Guid K_Problem_code)
        {

            return dal.GetModel(K_Problem_code);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.KMS.K_Problem GetModelByCache(int K_Problem_id)
        {

            string CacheKey = "K_ProblemModel-" + K_Problem_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(K_Problem_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.KMS.K_Problem)objModel;
        }
        /// <summary>
        /// 获取热门问题
        /// </summary>
        /// <returns></returns>
        public List<Model.KMS.K_Problem> GetListByBrowseCount()
        {
            return DataTableToList(dal.GetListByBrowseCount().Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Problem> GetList(string strWhere)
        {
            return DataTableToList(dal.GetList(strWhere).Tables[0]);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Problem> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Problem> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.KMS.K_Problem> modelList = new List<CommonService.Model.KMS.K_Problem>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.KMS.K_Problem model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return dal.GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.KMS.K_Problem model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Problem> GetListByPage(CommonService.Model.KMS.K_Problem model, string orderby, int startIndex, int endIndex)
        {
            return DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
        /// <summary>
        /// 获取当月记录总数
        /// </summary>
        public int GetRecordCountByMonth(CommonService.Model.KMS.K_Problem model)
        {
            return dal.GetRecordCountByMonth(model);
        }
        /// <summary>
        /// 获得要查询的数据列表
        /// </summary>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Problem> GetSearchList(int Top, string strWhere, string filedOrder)
        {
            return DataTableToList(dal.GetSearchList(Top, strWhere, filedOrder).Tables[0]);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="list">要查询的列表</param>
        /// <param name="keyWord">查询关键字</param>
        /// <param name="Top">查询前几条数据，为空时默认查询所有</param>
        /// <param name="strWhere">查询条件，可为空</param>
        /// <param name="filedOrder">数据排序，可为空</param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Problem> SearchResources(string path, string keyWord, int Top, string strWhere, string filedOrder)
        {
            DirectoryInfo INDEX_DIR = new DirectoryInfo(path);  //为防止多用户同时访问一个索引
            Analyzer analyzer = new Lucene.Net.Analysis.PanGu.PanGuAnalyzer(); //MMSegAnalyzer //StandardAnalyzer

            List<CommonService.Model.KMS.K_Problem> list = GetSearchList(Top, strWhere, filedOrder);
            IndexWriter iw = new IndexWriter(FSDirectory.Open(INDEX_DIR), analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
            foreach (CommonService.Model.KMS.K_Problem item in list)
            {
                CreateIndex(iw, item);
            }
            iw.Commit();
            iw.Optimize();
            iw.Dispose();
            string keyword = keyWord;
            IndexSearcher searcher = new IndexSearcher(FSDirectory.Open(INDEX_DIR), true);
            QueryParser qp = null;
            string[] field = { "K_Problem_content", "P_Flow_name", "F_Form_chineseName" };
            qp = new MultiFieldQueryParser(version, field, analyzer);//多字段查询
            Query query = qp.Parse(keyword); //
            TopDocs tds = searcher.Search(query, 10000);//给与10000条的上限
            List<CommonService.Model.KMS.K_Problem> sList = new List<Model.KMS.K_Problem>();
            for (int i = 0; i < tds.ScoreDocs.Length; i++)
            {
                ScoreDoc sd = tds.ScoreDocs[i];
                CommonService.Model.KMS.K_Problem model = new Model.KMS.K_Problem();
                Document doc = searcher.Doc(sd.Doc);
                //PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter = new PanGu.HighLight.SimpleHTMLFormatter("<font style=\"color:red\">", "</font>");
                //PanGu.HighLight.Highlighter highlighter = new PanGu.HighLight.Highlighter(simpleHTMLFormatter, new PanGu.Segment());
                //highlighter.FragmentSize = 1000;
                //关键字变红
                //model.K_Resources_description = highlighter.GetBestFragment(keyword, model.K_Resources_description);
                //model.K_Resources_name = highlighter.GetBestFragment(keyword, model.K_Resources_name);
                model.K_Problem_id = Convert.ToInt32(doc.Get("K_Problem_id"));
                model.K_Problem_code = new Guid(doc.Get("K_Problem_code"));
                model.K_Problem_content = doc.Get("K_Problem_content");
                model.K_Problem_statue = Convert.ToInt32(doc.Get("K_Problem_statue"));//model.K_Problem_statue;
                model.K_Problem_statueName = doc.Get("K_Problem_statueName");
                model.K_Problem_AnswerCount = Convert.ToInt32(doc.Get("K_Problem_AnswerCount"));
                model.K_Problem_createTime = model.K_Problem_createTime;
                model.K_Problem_isDelete = model.K_Problem_isDelete;
                sList.Add(model);
            }
            return sList;
        }

        /// <summary>
        /// 查询数据返回对应的问题code集合--如需修改，请告知--陈永俊
        /// </summary>
        /// <param name="path">索引路径</param>
        /// <param name="keyWord">关键字</param>
        /// <returns></returns>
        public string GetProblemCodeItems(string path, string keyWord)
        {
            DirectoryInfo INDEX_DIR = new DirectoryInfo(path);  //创建索引
            Analyzer analyzer = new Lucene.Net.Analysis.PanGu.PanGuAnalyzer(); //MMSegAnalyzer //StandardAnalyzer

            List<CommonService.Model.KMS.K_Problem> list = GetList("");
            IndexWriter iw = new IndexWriter(FSDirectory.Open(INDEX_DIR), analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
            foreach (CommonService.Model.KMS.K_Problem item in list)
            {
                CreateIndex(iw, item);
            }
            iw.Commit();
            iw.Optimize();
            iw.Dispose();
            string keyword = keyWord;
            keyword = GetKeyWordsSplitBySpace(keyword);//分词
            IndexSearcher searcher = new IndexSearcher(FSDirectory.Open(INDEX_DIR), true);
            QueryParser qp = null;
            string[] field = { "K_Problem_content", "P_Flow_name", "F_Form_chineseName" };
            qp = new MultiFieldQueryParser(version, field, analyzer);//多字段查询
            Query query = qp.Parse(keyword); //
            //#region   对分词进行处理  如果要修改，请告诉本人  --   陈永俊
            //if ((!(keyword.IndexOf(" ") > 0)) && query.ToString("K_Problem_content").IndexOf(" ") > 0)
            //{
            //    string strNew = "";
            //    string strQuery = query.ToString("K_Problem_content").Substring(1, query.ToString("K_Problem_content").Length - 2);
            //    //把经过分词之后的字符串，从新分配关键词
            //    string[] KeyItem = strQuery.Split(' ');
            //    for (int i = 0; i < KeyItem.Length; i++)
            //    {
            //        if (KeyItem[i].Length >= 2)//去掉单元词
            //        {
            //            strNew = strNew + KeyItem[i] + " ";
            //        }
            //    }
            //    query = qp.Parse(strNew);
            //}
            //#endregion
            TopDocs tds = searcher.Search(query, (Filter)null, 10000);//给与10000条的上限
            string sb = "";
            for (int i = 0; i < tds.ScoreDocs.Length; i++)
            {
                ScoreDoc sd = tds.ScoreDocs[i];
                CommonService.Model.KMS.K_Problem model = new Model.KMS.K_Problem();
                Document doc = searcher.Doc(sd.Doc);
                //PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter = new PanGu.HighLight.SimpleHTMLFormatter("<font style=\"color:red\">", "</font>");
                //PanGu.HighLight.Highlighter highlighter = new PanGu.HighLight.Highlighter(simpleHTMLFormatter, new PanGu.Segment());
                //highlighter.FragmentSize = 1000;
                //关键字变红
                //model.K_Resources_description = highlighter.GetBestFragment(keyword, model.K_Resources_description);
                //model.K_Resources_name = highlighter.GetBestFragment(keyword, model.K_Resources_name);
                model.K_Problem_code = new Guid(doc.Get("K_Problem_code"));
                sb += doc.Get("K_Problem_code") + ",";
            }
            string strresult = "";
            if (sb != "")
            {
                sb = sb.Substring(0, sb.Length - 1);
                string[] strs = sb.Split(',');

                for (int i = 0; i < strs.Length; i++)
                {
                    if (strresult == "")
                    { strresult += "'" + strs[i] + "'"; }
                    else
                    {
                        strresult += ",'" + strs[i] + "'";
                    }
                }
            }
            return strresult;
        }
        #region 对要搜索的词分词

        /// <summary>
        /// 对要搜索的词分词-----------陈盼盼
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="ktTokenizer"></param>
        /// <returns></returns>
        static public string GetKeyWordsSplitBySpace(string keywords)
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

        public bool CreateIndex(IndexWriter writer, CommonService.Model.KMS.K_Problem data)
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
        private static Lucene.Net.Util.Version _version = Lucene.Net.Util.Version.LUCENE_30;
        /// <summary>
        /// 版本号枚举类
        /// </summary>
        public Lucene.Net.Util.Version version
        {
            get
            {
                return _version;
            }
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

