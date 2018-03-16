using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Reflection;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System.IO;
using Lucene.Net.Analysis;
using CommonService.Common;
using System.Text;
using PanGu.Match;
using PanGu;
namespace CommonService.BLL.KMS
{
    /// <summary>
    /// 资源表逻辑
    /// 作者：崔慧栋
    /// 日期：2015/10/26
    /// </summary>
    public partial class K_Resources
    {
        private readonly CommonService.DAL.KMS.K_Resources dal = new CommonService.DAL.KMS.K_Resources();
        private readonly CommonService.DAL.KMS.K_Knowledge_Resources knowledgeResourcesDal = new CommonService.DAL.KMS.K_Knowledge_Resources();
        private readonly CommonService.BLL.KMS.K_Keyword_Resources keywordResourcesBll = new CommonService.BLL.KMS.K_Keyword_Resources();
        private readonly CommonService.DAL.KMS.K_Keyword_Resources keywordResourcesDal = new CommonService.DAL.KMS.K_Keyword_Resources();
        private readonly CommonService.DAL.KMS.K_Keyword keywordDal = new CommonService.DAL.KMS.K_Keyword();
        private readonly CommonService.DAL.KMS.K_Comments commentDal = new CommonService.DAL.KMS.K_Comments();
        private readonly CommonService.BLL.KMS.K_Comments commentBll = new CommonService.BLL.KMS.K_Comments();
        private readonly CommonService.DAL.C_Messages messageDal = new CommonService.DAL.C_Messages();
        public K_Resources()
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
        public bool Exists(int K_Resources_id)
        {
            return dal.Exists(K_Resources_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CommonService.Model.KMS.K_Resources model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CommonService.Model.KMS.K_Resources model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid K_Resources_code)
        {
            dal.Delete(K_Resources_code);
            //删除关联关键字（只删除关联关系）         
            keywordResourcesDal.DeleteByResourcesCode(K_Resources_code);
            //删除该资源下的所有评论
            commentDal.DeleteByFkCode(K_Resources_code);
            List<CommonService.Model.KMS.K_Comments> comments = commentBll.GetCommentsListByCode(K_Resources_code);
            foreach (CommonService.Model.KMS.K_Comments comment in comments)
            {
                commentDal.Delete(comment.K_Comments_code.Value);//删除评论
                messageDal.DeleteByLink(comment.K_Comments_code.Value);//删除关联消息
                deleteChild(comment.K_Comments_code.Value);//删除资源子级评论
            }
            return true;
        }
        public bool DeleteList(string K_Resources_idlist)
        {
            K_Resources_idlist = "'" + K_Resources_idlist + "'";
            bool result = dal.DeleteList(K_Resources_idlist);
            if (result)
            {
                string[] code = K_Resources_idlist.Split(',');
                foreach (string item in code)
                {
                    string resCode = item.Substring(1, item.Length - 2);
                    //删除关联关键字（只删除关联关系）         
                    keywordResourcesDal.DeleteByResourcesCode(new Guid(resCode));
                    //删除该资源下的所有评论
                    commentDal.DeleteByFkCode(new Guid(resCode));
                    List<CommonService.Model.KMS.K_Comments> comments = commentBll.GetCommentsListByCode(new Guid(resCode));
                    foreach (CommonService.Model.KMS.K_Comments comment in comments)
                    {
                        commentDal.Delete(comment.K_Comments_code.Value);//删除评论
                        messageDal.DeleteByLink(comment.K_Comments_code.Value);//删除关联消息
                        deleteChild(comment.K_Comments_code.Value);//删除资源子级评论
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
                deleteChild(comment.K_Comments_code.Value);//删除问题子级评论
            }
        }
        /// <summary>
        /// 资源审核
        /// </summary>
        /// <param name="resourcesCode">资源Guid</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public bool ResourcesAudit(string resourcesCode, int state)
        {
            resourcesCode = "'" + resourcesCode + "'";
            return dal.ResourcesAudit(resourcesCode, state);
        }
        /// <summary>
        /// 资源下载权限
        /// </summary>
        /// <param name="resourcesCode">资源Guid(以逗号隔开，多个处理)</param>
        /// <returns></returns>
        public bool ResourcesPermissions(string resourcesCode, int permissions)
        {
            resourcesCode = "'" + resourcesCode + "'";
            return dal.ResourcesPermissions(resourcesCode, permissions);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Resources GetModel(int K_Resources_id)
        {

            return dal.GetModel(K_Resources_id);
        }

        /// <summary>
        /// 根据视频Id获得一条数据
        /// </summary>
        /// <param name="K_Resources_url"></param>
        /// <returns></returns>
        public CommonService.Model.KMS.K_Resources GetModelByUrl(string K_Resources_url)
        {
            return dal.GetModelByUrl(K_Resources_url);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CommonService.Model.KMS.K_Resources GetModel(Guid K_Resources_code)
        {
            CommonService.Model.KMS.K_Resources resources = dal.GetModel(K_Resources_code);

            #region 资源关联关键字赋值
            List<CommonService.Model.KMS.K_Keyword_Resources> keywordResources = keywordResourcesBll.GetListByResourcesCode(K_Resources_code);
            foreach (CommonService.Model.KMS.K_Keyword_Resources item in keywordResources)
            {
                CommonService.Model.KMS.K_Keyword keyword = keywordDal.GetModel(item.K_Keyword_code.Value);
                resources.K_Resources_Keyword += keyword.K_Keyword_name + ",";
            }
            resources.K_Resources_Keyword = resources.K_Resources_Keyword == null ? resources.K_Resources_Keyword : resources.K_Resources_Keyword.Substring(0, resources.K_Resources_Keyword.Length - 1);
            #endregion

            return resources;
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public CommonService.Model.KMS.K_Resources GetModelByCache(int K_Resources_id)
        {

            string CacheKey = "K_ResourcesModel-" + K_Resources_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(K_Resources_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (CommonService.Model.KMS.K_Resources)objModel;
        }
        /// <summary>
        /// 获取最近上传几条数据
        /// </summary>
        /// <param name="K_Resources_creator">用户Guid</param>
        /// <param name="pageSize">展示条数</param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> GetListByRecentUpload(Guid K_Resources_creator, int pageSize)
        {
            return DataTableToList(dal.GetListByRecentUpload(K_Resources_creator, pageSize).Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="code">K_Resources_code数据集</param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> GetListByCode(string code)
        {
            DataSet ds = dal.GetList("K_Resources_code in ('" + code + "')");
            return DataTableToList(ds.Tables[0]);
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
        public List<CommonService.Model.KMS.K_Resources> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 根据资源类型获取前几条最热的数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="K_Knowledge_code"></param>
        /// <param name="K_Knowledge_Resources_type"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> GetListByzambiaCount(int count, string K_Knowledge_name, int? K_Knowledge_Resources_type)
        {
            return DataTableToList(dal.GetListByzambiaCount(count, K_Knowledge_name, K_Knowledge_Resources_type).Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Resources> DataTableToList(DataTable dt)
        {
            List<CommonService.Model.KMS.K_Resources> modelList = new List<CommonService.Model.KMS.K_Resources>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CommonService.Model.KMS.K_Resources model;
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
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(CommonService.Model.KMS.K_Resources model)
        {
            return dal.GetRecordCount(model);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Resources> GetListByPage(CommonService.Model.KMS.K_Resources model, string orderby, int startIndex, int endIndex)
        {
            List<CommonService.Model.KMS.K_Resources> resourcesList = DataTableToList(dal.GetListByPage(model, orderby, startIndex, endIndex).Tables[0]);
            foreach (CommonService.Model.KMS.K_Resources resource in resourcesList)
            {
                resource.K_Browse_LogCount = resource.K_Browse_LogCount == null ? 0 : resource.K_Browse_LogCount;
                resource.K_Resources_collectionCount = resource.K_Resources_collectionCount == null ? 0 : resource.K_Resources_collectionCount;
                resource.K_Resources_zambiaCount = resource.K_Resources_zambiaCount == null ? 0 : resource.K_Resources_zambiaCount;

                resource.K_Resources_Situation += "浏览量（" + resource.K_Browse_LogCount + "）";
                resource.K_Resources_Situation += "收藏（" + resource.K_Resources_collectionCount + "）";
                resource.K_Resources_Situation += "点赞（" + resource.K_Resources_zambiaCount + "）";
            }
            return resourcesList;
        }
        /// <summary>
        /// 我的文档/视频
        /// </summary>
        /// <param name="model"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Model.KMS.K_Resources> MyDocumentAndVideoList(CommonService.Model.KMS.K_Resources model, string orderby, int startIndex, int endIndex, int type)
        {
            return DataTableToList(dal.MyDocumentAndVideoList(model, orderby, startIndex, endIndex, type).Tables[0]);
        }

        /// <summary>
        /// 我的文档/视频数量
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int MyDocumentAndVideoListCount(Model.KMS.K_Resources model, int type)
        {
            return dal.MyDocumentAndVideoListCount(model, type);
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
        public int GetRecordCountByMonth(CommonService.Model.KMS.K_Resources model)
        {
            return dal.GetRecordCountByMonth(model);
        }
        /// <summary>
        /// 根据浏览量和资源类型获取前几天数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="K_Knowledge_code"></param>
        /// <param name="K_Knowledge_Resources_type"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> GetListByBrowseCount(int count, Guid? K_Knowledge_code, int? K_Resources_type)
        {
            return DataTableToList(dal.GetListByBrowseCount(count, K_Knowledge_code, K_Resources_type).Tables[0]);
        }
        /// <summary>
        /// 获得所有数据列表
        /// </summary>
        public List<CommonService.Model.KMS.K_Resources> GetSearchList()
        {
            return DataTableToList(dal.GetSearchList().Tables[0]);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="list">要查询的列表</param>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> SearchResources(string path, string keyWord)
        {
            DirectoryInfo INDEX_DIR = new DirectoryInfo(path);  //为防止多用户同时访问一个索引
            Analyzer analyzer = new Lucene.Net.Analysis.PanGu.PanGuAnalyzer(); //MMSegAnalyzer //StandardAnalyzer

            List<CommonService.Model.KMS.K_Resources> list = GetSearchList();
            IndexWriter iw = new IndexWriter(FSDirectory.Open(INDEX_DIR), analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
            foreach (CommonService.Model.KMS.K_Resources item in list)
            {
                CreateIndex(iw, item);
            }
            iw.Commit();
            iw.Optimize();
            iw.Dispose();
            string keyword = keyWord;
            IndexSearcher searcher = new IndexSearcher(FSDirectory.Open(INDEX_DIR), true);
            QueryParser qp = null;
            string[] field = { "K_Resources_name", "K_Resources_description", "K_Resources_Keyword", "P_Flow_name", "F_Form_chineseName" };
            qp = new MultiFieldQueryParser(version, field, analyzer);//多字段查询
            Query query = qp.Parse(keyword); //
            TopDocs tds = searcher.Search(query, 10000);//给与10000条的上限
            List<CommonService.Model.KMS.K_Resources> sList = new List<Model.KMS.K_Resources>();
            for (int i = 0; i < tds.ScoreDocs.Length; i++)
            {
                ScoreDoc sd = tds.ScoreDocs[i];
                CommonService.Model.KMS.K_Resources model = new Model.KMS.K_Resources();
                Document doc = searcher.Doc(sd.Doc);
                //PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter = new PanGu.HighLight.SimpleHTMLFormatter("<font style=\"color:red\">", "</font>");
                //PanGu.HighLight.Highlighter highlighter = new PanGu.HighLight.Highlighter(simpleHTMLFormatter, new PanGu.Segment());
                //highlighter.FragmentSize = 1000;
                model.K_Resources_id = Convert.ToInt32(doc.Get("K_Resources_id"));
                model.K_Resources_code = new Guid(doc.Get("K_Resources_code"));
                if (model.K_Resources_type != Convert.ToInt32(ResourcesTypeEnum.文章))
                    model.K_Resources_name = doc.Get("K_Resources_name").Split('.')[0];
                else
                    model.K_Resources_name = doc.Get("K_Resources_name");
                if (!string.IsNullOrEmpty(doc.Get("K_Resources_type")))
                    model.K_Resources_type = Convert.ToInt32(doc.Get("K_Resources_type"));
                if (!string.IsNullOrEmpty(doc.Get("K_Resources_state")))
                    model.K_Resources_state = Convert.ToInt32(doc.Get("K_Resources_state"));
                if (!string.IsNullOrEmpty(doc.Get("K_Resources_zambiaCount")))
                    model.K_Resources_zambiaCount = Convert.ToInt32(doc.Get("K_Resources_zambiaCount"));
                if (!string.IsNullOrEmpty(doc.Get("K_Resources_collectionCount")))
                    model.K_Resources_collectionCount = Convert.ToInt32(doc.Get("K_Resources_collectionCount"));
                if (!string.IsNullOrEmpty(doc.Get("K_Browse_LogCount")))
                    model.K_Browse_LogCount = Convert.ToInt32(doc.Get("K_Browse_LogCount"));
                if (!string.IsNullOrEmpty(doc.Get("K_Resources_downloadCount")))
                    model.K_Resources_downloadCount = Convert.ToInt32(doc.Get("K_Resources_downloadCount"));
                if (!string.IsNullOrEmpty(doc.Get("K_Resources_nouserCount")))
                    model.K_Resources_nouserCount = Convert.ToInt32(doc.Get("K_Resources_nouserCount"));
                model.K_Resources_Extension = doc.Get("K_Resources_Extension");
                model.K_Resources_description = doc.Get("K_Resources_description");
                model.K_Resources_coverImage = doc.Get("K_Resources_coverImage");
                model.K_Resources_createTime = Convert.ToDateTime(doc.Get("K_Resources_createTime"));
                model.K_Resources_creator = new Guid(doc.Get("K_Resources_creator"));
                model.K_Resources_isDelete = doc.Get("K_Resources_isDelete") == "0" ? false : true;
                model.K_Resources_url = doc.Get("K_Resources_url");
                model.K_Resources_author = doc.Get("K_Resources_author");
                //关键字变红
                //model.K_Resources_description = highlighter.GetBestFragment(keyword, model.K_Resources_description);
                //model.K_Resources_name = highlighter.GetBestFragment(keyword, model.K_Resources_name);
                sList.Add(model);
            }
            return sList;
        }
        /// <summary>
        /// 根据资源code集合获得资源集合
        /// </summary>
        /// <param name="codeList"></param>
        /// <returns></returns>
        public List<CommonService.Model.KMS.K_Resources> GetListByCodeList(string codeList, string type)
        {
            return DataTableToList(dal.GetListByCodeList(codeList,type).Tables[0]);
        }
        /// <summary>
        /// 根据查询关键字，返回查询到的数据code--如需修改，请告知--陈永俊
        /// 修改过----陈盼盼
        /// </summary>
        /// <param name="list">要查询的列表</param>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        public string GetResourcesCodelist(string path, string keyWord)
        {
            DirectoryInfo INDEX_DIR = new DirectoryInfo(path);  //为防止多用户同时访问一个索引
            Analyzer analyzer = new Lucene.Net.Analysis.PanGu.PanGuAnalyzer(); //MMSegAnalyzer //StandardAnalyzer

            List<CommonService.Model.KMS.K_Resources> list = GetSearchList();
            IndexWriter iw = new IndexWriter(FSDirectory.Open(INDEX_DIR), analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
            foreach (CommonService.Model.KMS.K_Resources item in list)
            {
                CreateIndex(iw, item);
            }
            iw.Commit();
            iw.Optimize();
            iw.Dispose();
            string keyword = keyWord;
            IndexSearcher searcher = new IndexSearcher(FSDirectory.Open(INDEX_DIR), true);

            QueryParser qp = null;
            string[] field = { "K_Resources_name", "K_Resources_description", "K_Resources_Keyword", "P_Flow_name", "F_Form_chineseName" };
            keyword = GetKeyWordsSplitBySpace(keyword);//分词
            qp = new MultiFieldQueryParser(version, field, analyzer);//多字段查询
            Query query = qp.Parse(keyword); //
            //先进行分词，然后对分词后的结果进行判断 判断之后，从新组合然后进行查询
            //QueryParser qpdemo = new QueryParser(version, "body", analyzer);
            //Query querydemo = qpdemo.Parse(keyword);
            //if ((!(keyword.IndexOf(" ") > 0)) && querydemo.ToString("body").IndexOf(" ") > 0)
            //{
            //    string strNew = "";
            //    string strQuery = querydemo.ToString("body").Substring(1, querydemo.ToString("body").Length - 2);
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
            TopDocs tds = searcher.Search(query, (Filter)null, 10000);//给与10000条的上限
            string sb = "";
            for (int i = 0; i < tds.ScoreDocs.Length; i++)
            {
                ScoreDoc sd = tds.ScoreDocs[i];
                Document doc = searcher.Doc(sd.Doc);
                sb += doc.Get("K_Resources_code").ToString() + ",";
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

        public bool CreateIndex(IndexWriter writer, CommonService.Model.KMS.K_Resources data)
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

