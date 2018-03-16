using CommonClient.Types;

namespace CommonClient.ConvertHelper
{
    public enum CountryHelper
    {
        [TranslatingKeyAttribute("Ch1", "阿尔巴尼亚", "Albania", "")]
        ALB = 008,
        [TranslatingKeyAttribute("Ch2", "阿尔及利亚", "Algeria", "")]
        DZA = 012,
        [TranslatingKeyAttribute("Ch3", "阿富汗", "Afghanistan", "")]
        AFG = 004,
        [TranslatingKeyAttribute("Ch4", "阿根廷", "Argentina", "")]
        ARG = 032,
        [TranslatingKeyAttribute("Ch5", "阿联酋", "United Arab Emirates", "")]
        ARE = 784,
        [TranslatingKeyAttribute("Ch6", "阿鲁巴", "ARUBA", "")]
        ABW = 533,
        [TranslatingKeyAttribute("Ch7", "阿曼", "Oman", "")]
        OMN = 512,
        [TranslatingKeyAttribute("Ch8", "阿塞拜疆", "Azerbaijan", "")]
        AZE = 031,
        [TranslatingKeyAttribute("Ch9", "埃及", "Egypt", "")]
        EGY = 818,
        [TranslatingKeyAttribute("Ch10", "埃塞俄比亚", "Ethiopia", "")]
        ETH = 231,
        [TranslatingKeyAttribute("Ch11", "爱尔兰", "Ireland", "")]
        IRL = 372,
        [TranslatingKeyAttribute("Ch12", "爱沙尼亚", "Estonia", "")]
        EST = 233,
        [TranslatingKeyAttribute("Ch13", "安道尔", "Andorra", "")]
        AND = 020,
        [TranslatingKeyAttribute("Ch14", "安哥拉", "Angola", "")]
        AGO = 024,
        [TranslatingKeyAttribute("Ch15", "安圭拉", "Anguilla", "")]
        AIA = 660,
        [TranslatingKeyAttribute("Ch16", "安提瓜和巴布达", "Antigua and Barbuda", "")]
        ATG = 028,
        [TranslatingKeyAttribute("Ch17", "奥地利", "Austria", "")]
        AUT = 040,
        [TranslatingKeyAttribute("Ch18", "澳大利亚", "Australia", "")]
        AUS = 036,
        [TranslatingKeyAttribute("Ch19", "澳门", "Macau", "")]
        MAC = 446,
        [TranslatingKeyAttribute("Ch20", "巴巴多斯", "Barbados", "")]
        BRB = 052,
        [TranslatingKeyAttribute("Ch21", "巴布亚新几内亚", "Papua New Guinea", "")]
        PNG = 598,
        [TranslatingKeyAttribute("Ch22", "巴哈马", "Bahamas", "")]
        BHS = 044,
        [TranslatingKeyAttribute("Ch23", "巴基斯坦", "Pakistan", "")]
        PAK = 586,
        [TranslatingKeyAttribute("Ch24", "巴拉圭", "Paraguay", "")]
        PRY = 600,
        [TranslatingKeyAttribute("Ch25", "巴勒斯坦", "Palestine", "")]
        PSE = 275,
        [TranslatingKeyAttribute("Ch26", "巴林", "Bahrain", "")]
        BHR = 048,
        [TranslatingKeyAttribute("Ch27", "巴拿马", "Panama", "")]
        PAN = 591,
        [TranslatingKeyAttribute("Ch28", "巴西", "Brazil", "")]
        BRA = 076,
        [TranslatingKeyAttribute("Ch29", "白俄罗斯", "Belarus", "")]
        BLR = 112,
        [TranslatingKeyAttribute("Ch30", "百慕大", "Bermuda", "")]
        BMU = 060,
        [TranslatingKeyAttribute("Ch31", "保加利亚", "Bulgarian", "")]
        BGR = 100,
        [TranslatingKeyAttribute("Ch32", "北马里亚纳", "Northern Mariana Islands", "")]
        MNP = 580,
        [TranslatingKeyAttribute("Ch33", "贝宁", "Benin", "")]
        BEN = 204,
        [TranslatingKeyAttribute("Ch34", "比利时", "Belgium", "")]
        BEL = 056,
        [TranslatingKeyAttribute("Ch35", "秘鲁", "Peru", "")]
        PER = 604,
        [TranslatingKeyAttribute("Ch36", "冰岛", "Iceland", "")]
        ISL = 352,
        [TranslatingKeyAttribute("Ch37", "波多黎各", "Puerto Rico", "")]
        PRI = 630,
        [TranslatingKeyAttribute("Ch38", "波黑", "Bosnia and Herzegovina", "")]
        BIH = 070,
        [TranslatingKeyAttribute("Ch39", "波兰", "Poland", "")]
        POL = 616,
        [TranslatingKeyAttribute("Ch40", "玻利维亚", "Bolivia", "")]
        BOL = 068,
        [TranslatingKeyAttribute("Ch41", "伯利兹", "Belize", "")]
        BLZ = 084,
        [TranslatingKeyAttribute("Ch42", "博茨瓦纳", "Botswana", "")]
        BWA = 072,
        [TranslatingKeyAttribute("Ch43", "不丹", "Bhutan", "")]
        BTN = 064,
        [TranslatingKeyAttribute("Ch44", "布基纳法索", "Burkina Faso", "")]
        BFA = 854,
        [TranslatingKeyAttribute("Ch45", "布隆迪", "Burundi", "")]
        BDI = 108,
        [TranslatingKeyAttribute("Ch46", "布维岛", "Bouvet Island", "")]
        BVT = 074,
        [TranslatingKeyAttribute("Ch47", "朝鲜", "North Korea", "")]
        PRK = 408,
        [TranslatingKeyAttribute("Ch48", "赤道几内亚", "Equatorial Guinea", "")]
        GNQ = 226,
        [TranslatingKeyAttribute("Ch49", "丹麦", "Denmark", "")]
        DNK = 208,
        [TranslatingKeyAttribute("Ch50", "德国", "Germany", "")]
        DEU = 276,
        [TranslatingKeyAttribute("Ch51", "东帝汶", "East Timor", "")]
        TMP = 626,
        [TranslatingKeyAttribute("Ch52", "多哥", "Togo", "")]
        TGO = 768,
        [TranslatingKeyAttribute("Ch53", "多米尼加", "Dominican Republic", "")]
        DOM = 214,
        [TranslatingKeyAttribute("Ch54", "多米尼克", "Dominica", "")]
        DMA = 212,
        [TranslatingKeyAttribute("Ch55", "俄罗斯联邦", "Russian Federation", "")]
        RUS = 643,
        [TranslatingKeyAttribute("Ch56", "厄瓜多尔", "Ecuador", "")]
        ECU = 218,
        [TranslatingKeyAttribute("Ch57", "厄立特里亚", "Eritrea", "")]
        ERI = 232,
        [TranslatingKeyAttribute("Ch58", "法国", "France", "")]
        FRA = 250,
        [TranslatingKeyAttribute("Ch59", "法罗群岛（丹）", "Faroe Islands (Denmark)", "")]
        FRO = 234,
        [TranslatingKeyAttribute("Ch60", "法属波利尼西亚", "French Polynesia", "")]
        PYF = 258,
        [TranslatingKeyAttribute("Ch61", "法属圭亚那", "French Guiana", "")]
        GUF = 254,
        [TranslatingKeyAttribute("Ch62", "法属南部领土", "FRENCH SOUTHERN TERRITORIES", "")]
        ATF = 260,
        [TranslatingKeyAttribute("Ch63", "梵蒂冈", "Vatican City", "")]
        VAT = 336,
        [TranslatingKeyAttribute("Ch64", "菲律宾", "Philippines", "")]
        PHL = 608,
        [TranslatingKeyAttribute("Ch65", "斐济", "Fiji", "")]
        FJI = 242,
        [TranslatingKeyAttribute("Ch66", "芬兰", "Finland", "")]
        FIN = 246,
        [TranslatingKeyAttribute("Ch67", "佛得角", "Cape Verde", "")]
        CPV = 132,
        [TranslatingKeyAttribute("Ch68", "福克兰群岛(马尔维纳斯)", "FALKLAND ISLANDS (MALVINAS)", "")]
        FLK = 238,
        [TranslatingKeyAttribute("Ch69", "冈比亚", "Gambia", "")]
        GMB = 270,
        [TranslatingKeyAttribute("Ch70", "刚果(布)", "Congo (Brazzaville)", "")]
        COG = 178,
        [TranslatingKeyAttribute("Ch71", "刚果(金)", "Congo (DRC)", "")]
        COD = 180,
        [TranslatingKeyAttribute("Ch72", "哥伦比亚", "Colombia", "")]
        COL = 170,
        [TranslatingKeyAttribute("Ch73", "哥斯达黎加", "Costa Rica", "")]
        CRI = 188,
        [TranslatingKeyAttribute("Ch74", "格林纳达", "Grenada", "")]
        GRD = 308,
        [TranslatingKeyAttribute("Ch75", "格陵兰（丹）", "Greenland (Denmark)", "")]
        GRL = 304,
        [TranslatingKeyAttribute("Ch76", "格鲁吉亚", "Georgia", "")]
        GEO = 268,
        [TranslatingKeyAttribute("Ch77", "古巴", "Cuba", "")]
        CUB = 192,
        [TranslatingKeyAttribute("Ch78", "瓜德罗普（法）", "Guadeloupe (French)", "")]
        GLP = 312,
        [TranslatingKeyAttribute("Ch79", "关岛", "Guam (U.S.)", "")]
        GUM = 316,
        [TranslatingKeyAttribute("Ch80", "圭亚那", "Guyana", "")]
        GUY = 328,
        [TranslatingKeyAttribute("Ch81", "哈萨克斯坦", "Kazakhstan", "")]
        KAZ = 398,
        [TranslatingKeyAttribute("Ch82", "海地", "Haiti", "")]
        HTI = 332,
        [TranslatingKeyAttribute("Ch83", "韩国", "South Korea", "")]
        KOR = 410,
        [TranslatingKeyAttribute("Ch84", "荷兰", "Netherlands", "")]
        NLD = 528,
        [TranslatingKeyAttribute("Ch85", "荷属安的列斯", "Netherlands Antilles", "")]
        ANT = 530,
        [TranslatingKeyAttribute("Ch86", "赫德岛和麦克唐纳岛", "Heard Island and McDonald Islands", "")]
        HMD = 334,
        [TranslatingKeyAttribute("Ch87", "洪都拉斯", "Honduras", "")]
        HND = 340,
        [TranslatingKeyAttribute("Ch88", "基里巴斯", "Kiribati", "")]
        KIR = 296,
        [TranslatingKeyAttribute("Ch89", "吉布提", "Djibouti", "")]
        DJI = 262,
        [TranslatingKeyAttribute("Ch90", "吉尔吉斯斯坦", "Kyrgyzstan", "")]
        KGZ = 417,
        [TranslatingKeyAttribute("Ch91", "几内亚", "Guinea", "")]
        GIN = 324,
        [TranslatingKeyAttribute("Ch92", "几内亚比绍", "Guinea-Bissau", "")]
        GNB = 624,
        [TranslatingKeyAttribute("Ch93", "加拿大", "Canada", "")]
        CAN = 124,
        [TranslatingKeyAttribute("Ch94", "加纳", "Ghana", "")]
        GHA = 288,
        [TranslatingKeyAttribute("Ch95", "加蓬", "Gabon", "")]
        GAB = 266,
        [TranslatingKeyAttribute("Ch96", "柬埔寨", "Cambodia", "")]
        KHM = 116,
        [TranslatingKeyAttribute("Ch97", "捷克", "Czech Republic", "")]
        CZE = 203,
        [TranslatingKeyAttribute("Ch98", "津巴布韦", "Zimbabwe", "")]
        ZWE = 716,
        [TranslatingKeyAttribute("Ch99", "喀麦隆", "Cameroon", "")]
        CMR = 120,
        [TranslatingKeyAttribute("Ch100", "卡塔尔", "Qatar", "")]
        QAT = 634,
        [TranslatingKeyAttribute("Ch101", "开曼群岛", "Cayman Islands", "")]
        CYM = 136,
        [TranslatingKeyAttribute("Ch102", "科科斯(基林)群岛", "COCOS(KEELING) ISLANDS", "")]
        CCK = 166,
        [TranslatingKeyAttribute("Ch103", "科摩罗", "Comoros", "")]
        COM = 174,
        [TranslatingKeyAttribute("Ch104", "科特迪瓦", "Côte d'Ivoire", "")]
        CIV = 384,
        [TranslatingKeyAttribute("Ch105", "科威特", "Kuwait", "")]
        KWT = 414,
        [TranslatingKeyAttribute("Ch106", "克罗地亚", "Croatia", "")]
        HRV = 191,
        [TranslatingKeyAttribute("Ch107", "肯尼亚", "Kenya", "")]
        KEN = 404,
        [TranslatingKeyAttribute("Ch108", "库克群岛（新）", "COOK ISLANDS", "")]
        COK = 184,
        [TranslatingKeyAttribute("Ch109", "拉脱维亚", "Latvia", "")]
        LVA = 428,
        [TranslatingKeyAttribute("Ch110", "莱索托", "Lesotho", "")]
        LSO = 426,
        [TranslatingKeyAttribute("Ch111", "老挝", "Laos", "")]
        LAO = 418,
        [TranslatingKeyAttribute("Ch112", "黎巴嫩", "Lebanon", "")]
        LBN = 422,
        [TranslatingKeyAttribute("Ch113", "立陶宛", "Lithuania", "")]
        LTU = 440,
        [TranslatingKeyAttribute("Ch114", "利比里亚", "Liberia", "")]
        LBR = 430,
        [TranslatingKeyAttribute("Ch115", "利比亚", "Libya", "")]
        LBY = 434,
        [TranslatingKeyAttribute("Ch116", "列支敦士登", "Liechtenstein", "")]
        LIE = 438,
        [TranslatingKeyAttribute("Ch117", "留尼汪（法）", "Reunion (French)", "")]
        REU = 638,
        [TranslatingKeyAttribute("Ch118", "卢森堡", "Luxembourg", "")]
        LUX = 442,
        [TranslatingKeyAttribute("Ch119", "卢旺达", "Rwanda", "")]
        RWA = 646,
        [TranslatingKeyAttribute("Ch120", "罗马尼亚", "Romania", "")]
        ROM = 642,
        [TranslatingKeyAttribute("Ch121", "马达加斯加", "Madagascar", "")]
        MDG = 450,
        [TranslatingKeyAttribute("Ch122", "马尔代夫", "Maldives", "")]
        MDV = 462,
        [TranslatingKeyAttribute("Ch123", "马耳他", "Malta", "")]
        MLT = 470,
        [TranslatingKeyAttribute("Ch124", "马拉维", "Malawi", "")]
        MWI = 454,
        [TranslatingKeyAttribute("Ch125", "马来西亚", "Malaysia", "")]
        MYS = 458,
        [TranslatingKeyAttribute("Ch126", "马里", "Mali", "")]
        MLI = 466,
        [TranslatingKeyAttribute("Ch127", "马绍尔群岛", "Marshall Islands", "")]
        MHL = 584,
        [TranslatingKeyAttribute("Ch128", "马提尼克（法）", "Martinique (French)", "")]
        MTQ = 474,
        [TranslatingKeyAttribute("Ch129", "马约特", "Mayotte", "")]
        MYT = 175,
        [TranslatingKeyAttribute("Ch130", "毛里求斯", "Mauritius", "")]
        MUS = 480,
        [TranslatingKeyAttribute("Ch131", "毛里塔尼亚", "Mauritania", "")]
        MRT = 478,
        [TranslatingKeyAttribute("Ch132", "美国", "United States", "")]
        USA = 840,
        [TranslatingKeyAttribute("Ch133", "美国本土外小岛屿", "United States Minor Outlying Islands", "")]
        UMI = 581,
        [TranslatingKeyAttribute("Ch134", "美属萨摩亚", "American Samoa", "")]
        ASM = 016,
        [TranslatingKeyAttribute("Ch135", "美属维尔京群岛", "United States Virgin Islands", "")]
        VIR = 850,
        [TranslatingKeyAttribute("Ch136", "蒙古", "Mongolia", "")]
        MNG = 496,
        [TranslatingKeyAttribute("Ch137", "蒙特塞拉特（法）", "Montserrat (French)", "")]
        MSR = 500,
        [TranslatingKeyAttribute("Ch138", "孟加拉国", "Bangladesh", "")]
        BGD = 050,
        [TranslatingKeyAttribute("Ch139", "密克罗尼西亚联邦", "Federated States of Micronesia", "")]
        FSM = 583,
        [TranslatingKeyAttribute("Ch140", "缅甸", "Myanmar", "")]
        MMR = 104,
        [TranslatingKeyAttribute("Ch141", "摩尔多瓦", "Moldova", "")]
        MDA = 498,
        [TranslatingKeyAttribute("Ch142", "摩洛哥", "Morocco", "")]
        MAR = 504,
        [TranslatingKeyAttribute("Ch143", "摩纳哥", "Monaco", "")]
        MCO = 492,
        [TranslatingKeyAttribute("Ch144", "莫桑比克", "Mozambique", "")]
        MOZ = 508,
        [TranslatingKeyAttribute("Ch145", "墨西哥", "México", "")]
        MEX = 484,
        [TranslatingKeyAttribute("Ch146", "纳米比亚", "Namibia", "")]
        NAM = 516,
        [TranslatingKeyAttribute("Ch147", "南非", "South Africa", "")]
        ZAF = 710,
        [TranslatingKeyAttribute("Ch148", "南极洲", "Antarctica", "")]
        ATA = 010,
        [TranslatingKeyAttribute("Ch149", "南乔治亚岛和南桑德韦奇岛", "South Georgia and the South Sandwich Islands", "")]
        SGS = 239,
        //[TranslatingKeyAttribute("Ch150", "南斯拉夫", "Yugoslavia", "")]
        //Ch150 = 891,
        [TranslatingKeyAttribute("Ch151", "瑙鲁", "Nauru", "")]
        NRU = 520,
        [TranslatingKeyAttribute("Ch152", "尼泊尔", "Nepal", "")]
        NPL = 524,
        [TranslatingKeyAttribute("Ch153", "尼加拉瓜", "Nicaragua", "")]
        NIC = 558,
        [TranslatingKeyAttribute("Ch154", "尼日尔", "Niger", "")]
        NER = 562,
        [TranslatingKeyAttribute("Ch155", "尼日利亚", "Nigeria", "")]
        NGA = 566,
        [TranslatingKeyAttribute("Ch156", "纽埃", "Niue", "")]
        NIU = 570,
        [TranslatingKeyAttribute("Ch157", "挪威", "Norway", "")]
        NOR = 578,
        [TranslatingKeyAttribute("Ch158", "诺福克岛", "Norfolk Island", "")]
        NFK = 574,
        [TranslatingKeyAttribute("Ch159", "帕劳", "Palau", "")]
        PLW = 585,
        [TranslatingKeyAttribute("Ch160", "皮特凯恩", "Pitcairn (UK)", "")]
        PCN = 612,
        [TranslatingKeyAttribute("Ch161", "葡萄牙", "Portugal", "")]
        PRT = 620,
        [TranslatingKeyAttribute("Ch162", "马其顿", "MACEDONIA", "")]
        MKD = 807,
        [TranslatingKeyAttribute("Ch163", "日本", "Japan", "")]
        JPN = 392,
        [TranslatingKeyAttribute("Ch164", "瑞典", "Sweden", "")]
        SWE = 752,
        [TranslatingKeyAttribute("Ch165", "瑞士", "Switzerland", "")]
        CHE = 756,
        [TranslatingKeyAttribute("Ch166", "萨尔瓦多", "El Salvador", "")]
        SLV = 222,
        [TranslatingKeyAttribute("Ch167", "萨摩亚", "Samoa", "")]
        WSM = 882,
        [TranslatingKeyAttribute("Ch168", "塞拉利昂", "Sierra Leone", "")]
        SLE = 694,
        [TranslatingKeyAttribute("Ch169", "塞内加尔", "Senegal", "")]
        SEN = 686,
        [TranslatingKeyAttribute("Ch170", "塞浦路斯", "Cyprus", "")]
        CYP = 196,
        [TranslatingKeyAttribute("Ch171", "塞舌尔", "Seychelles", "")]
        SYC = 690,
        [TranslatingKeyAttribute("Ch172", "沙特阿拉伯", "Saudi Arabia", "")]
        SAU = 682,
        [TranslatingKeyAttribute("Ch173", "圣诞岛", "Christmas Island", "")]
        CXR = 162,
        [TranslatingKeyAttribute("Ch174", "圣多美和普林西比", "Sao Tome and Principe", "")]
        STP = 678,
        [TranslatingKeyAttribute("Ch175", "圣赫勒拿", "SAINT HELENA", "")]
        SHN = 654,
        [TranslatingKeyAttribute("Ch176", "圣基茨和尼维斯", "Saint Kitts and Nevis", "")]
        KNA = 659,
        [TranslatingKeyAttribute("Ch177", "圣卢西亚", "Saint Lucia", "")]
        LCA = 662,
        [TranslatingKeyAttribute("Ch178", "圣马力诺", "San Marino", "")]
        SMR = 674,
        [TranslatingKeyAttribute("Ch179", "圣皮埃尔和密克隆", "Saint Pierre and Miquelon (France)", "")]
        SPM = 666,
        [TranslatingKeyAttribute("Ch180", "圣文森特和格林纳丁斯", "Saint Vincent and the Grenadines", "")]
        VCT = 670,
        [TranslatingKeyAttribute("Ch181", "斯里兰卡", "Sri Lanka", "")]
        LKA = 144,
        [TranslatingKeyAttribute("Ch182", "斯洛伐克", "Slovakia", "")]
        SVK = 703,
        [TranslatingKeyAttribute("Ch183", "斯洛文尼亚", "Slovenia", "")]
        SVN = 705,
        [TranslatingKeyAttribute("Ch184", "斯瓦尔巴岛和扬马延岛", "Svalbard and Jan Mayen", "")]
        SJM = 744,
        [TranslatingKeyAttribute("Ch185", "斯威士兰", "Swaziland", "")]
        SWZ = 748,
        [TranslatingKeyAttribute("Ch186", "苏丹", "Sudan", "")]
        SDN = 736,
        [TranslatingKeyAttribute("Ch187", "苏里南", "Surinam", "")]
        SUR = 740,
        [TranslatingKeyAttribute("Ch188", "所罗门群岛", "Solomon Islands", "")]
        SLB = 090,
        [TranslatingKeyAttribute("Ch189", "索马里", "Somalia", "")]
        SOM = 706,
        [TranslatingKeyAttribute("Ch190", "塔吉克斯坦", "Tajikistan", "")]
        TJK = 762,
        [TranslatingKeyAttribute("Ch191", "泰国", "Thailand", "")]
        THA = 764,
        [TranslatingKeyAttribute("Ch192", "坦桑尼亚", "Tanzania", "")]
        TZA = 834,
        [TranslatingKeyAttribute("Ch193", "汤加", "Tonga", "")]
        TON = 776,
        [TranslatingKeyAttribute("Ch194", "特克斯和凯科斯群岛", "Turks and Caicos Islands (British)", "")]
        TCA = 796,
        [TranslatingKeyAttribute("Ch195", "特立尼达和多巴哥", "Trinidad and Tobago", "")]
        TTO = 780,
        [TranslatingKeyAttribute("Ch196", "突尼斯", "Tunisia", "")]
        TUN = 788,
        [TranslatingKeyAttribute("Ch197", "图瓦卢", "Tuvalu", "")]
        TUV = 798,
        [TranslatingKeyAttribute("Ch198", "土耳其", "Turkey", "")]
        TUR = 792,
        [TranslatingKeyAttribute("Ch199", "土库曼斯坦", "Turkmenistan", "")]
        TKM = 795,
        [TranslatingKeyAttribute("Ch200", "托克劳", "Tokelau (New)", "")]
        TKL = 772,
        [TranslatingKeyAttribute("Ch201", "瓦利斯和富图纳", "Wallis and Futuna (France)", "")]
        WLF = 876,
        [TranslatingKeyAttribute("Ch202", "瓦努阿图", "Vanuatu", "")]
        VUT = 548,
        [TranslatingKeyAttribute("Ch203", "危地马拉", "Guatemala", "")]
        GTM = 320,
        [TranslatingKeyAttribute("Ch204", "委内瑞拉", "Venezuela", "")]
        VEN = 862,
        [TranslatingKeyAttribute("Ch205", "文莱", "Brunei", "")]
        BRN = 096,
        [TranslatingKeyAttribute("Ch206", "乌干达", "Uganda", "")]
        UGA = 800,
        [TranslatingKeyAttribute("Ch207", "乌克兰", "Ukraine", "")]
        UKR = 804,
        [TranslatingKeyAttribute("Ch208", "乌拉圭", "Uruguay", "")]
        URY = 858,
        [TranslatingKeyAttribute("Ch209", "乌兹别克斯坦", "Uzbekistan", "")]
        UZB = 860,
        [TranslatingKeyAttribute("Ch210", "西班牙", "Spain", "")]
        ESP = 724,
        [TranslatingKeyAttribute("Ch211", "西撒哈拉", "Western Sahara", "")]
        ESH = 732,
        [TranslatingKeyAttribute("Ch212", "希腊", "Greece", "")]
        GRC = 300,
        [TranslatingKeyAttribute("Ch213", "香港", "Hong Kong", "")]
        HKG = 344,
        [TranslatingKeyAttribute("Ch214", "新加坡", "Singapore", "")]
        SGP = 702,
        [TranslatingKeyAttribute("Ch215", "新喀里多尼亚", "New Caledonia (French)", "")]
        NCL = 540,
        [TranslatingKeyAttribute("Ch216", "新西兰", "New Zealand", "")]
        NZL = 554,
        [TranslatingKeyAttribute("Ch217", "匈牙利", "Hungary", "")]
        HUN = 348,
        [TranslatingKeyAttribute("Ch218", "叙利亚", "Syria", "")]
        SYR = 760,
        [TranslatingKeyAttribute("Ch219", "牙买加", "Jamaica", "")]
        JAM = 388,
        [TranslatingKeyAttribute("Ch220", "亚美尼亚", "Armenia", "")]
        ARM = 051,
        [TranslatingKeyAttribute("Ch221", "也门", "Yemen", "")]
        YEM = 887,
        [TranslatingKeyAttribute("Ch222", "伊拉克", "Iraq", "")]
        IRQ = 368,
        [TranslatingKeyAttribute("Ch223", "伊朗", "Iran", "")]
        IRN = 364,
        [TranslatingKeyAttribute("Ch224", "以色列", "Israel", "")]
        ISR = 376,
        [TranslatingKeyAttribute("Ch225", "意大利", "Italy", "")]
        ITA = 380,
        [TranslatingKeyAttribute("Ch226", "印度", "India", "")]
        IND = 356,
        [TranslatingKeyAttribute("Ch227", "印度尼西亚", "Indonesia", "")]
        IDN = 360,
        [TranslatingKeyAttribute("Ch228", "英国", "United Kingdom", "")]
        GBR = 826,
        [TranslatingKeyAttribute("Ch229", "英属维尔京群岛", "British Virgin Islands", "")]
        VGB = 092,
        [TranslatingKeyAttribute("Ch230", "英属印度洋领土", "BRITISH INDIAN OCEAN TERRITORY", "")]
        IOT = 086,
        [TranslatingKeyAttribute("Ch231", "约旦", "Jordan", "")]
        JOR = 400,
        [TranslatingKeyAttribute("Ch232", "越南", "Vietnam", "")]
        VNM = 704,
        [TranslatingKeyAttribute("Ch233", "赞比亚", "Zambia", "")]
        ZMB = 894,
        [TranslatingKeyAttribute("Ch234", "乍得", "Chad", "")]
        TCD = 148,
        [TranslatingKeyAttribute("Ch235", "直布罗陀", "Gibraltar", "")]
        GIB = 292,
        [TranslatingKeyAttribute("Ch236", "智利", "Chile", "")]
        CHL = 152,
        [TranslatingKeyAttribute("Ch237", "中非", "Central Africa", "")]
        CAF = 140,
        [TranslatingKeyAttribute("Ch238", "中国", "China", "")]
        CHN = 156,
        [TranslatingKeyAttribute("Ch239", "中国台湾", "Taiwan", "")]
        TWN = 158,
        [TranslatingKeyAttribute("Ch240", "马恩岛", "ISLE OF MAN", "")]
        IMN = 830,
        [TranslatingKeyAttribute("Ch241", "黑山", "Montenegro", "")]
        MNE = 499,
        [TranslatingKeyAttribute("Ch242", "塞尔维亚", "Serbia", "")]
        SRB = 688,
    }
}