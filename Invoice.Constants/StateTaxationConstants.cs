using System;

namespace Invoice.Constants
{
    public static class StateTaxationConstants
    {
        /// <summary>
        /// 河南国税局
        /// </summary>
        public const string HenanPost = "http://bsfwt.12366.ha.cn/bsfwt/sscx/getFpzwcxNew.do";

        /// <summary>
        /// 四川国税局
        /// </summary>
        public const string SichuanGet = "http://wsbs.sc-n-tax.gov.cn/sscx/fpcy.html";

        public const string SichuanPost = "http://wsbs.sc-n-tax.gov.cn/fpcy/query.htm";


        /// <summary>
        /// 重庆国税局
        /// </summary>
        public const string ChongqingGet = "http://12366.cqsw.gov.cn:5000/captcha.jpg";

        /// <summary>
        /// 河南国税局
        /// </summary>
        public const string HenanGet = "http://bsfwt.12366.ha.cn/bsfwt/sscx/showPictureCode.do";

        /// <summary>
        /// 天津国税局增值税电子普通
        /// </summary>
        public const string TianjinGet = "http://fpxxbd.tjsat.gov.cn:8001/fpxxbd/1490019010134.ht_jpeg";

        /// <summary>
        /// 天津国税局增值税电子普通
        /// </summary>
        public const string TianjinPost = "http://fpxxbd.tjsat.gov.cn:8001/fpxxbd/jdfp.query";
    }
}
