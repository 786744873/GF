

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using CommonClient.Controls;
using CommonClient.VisualParts;
using CommonClient.EnumTypes;

namespace CommonClient.Contract
{
    // 用于为ModuleWorkSpace注入额外属性和标记
    [AttributeUsageAttribute(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleWorkSpaceInfoAttribute : Attribute
    {
        public ModuleWorkSpaceInfoAttribute(string pluginName, bool initOnLoad, int displayIndex, string businessName, object tag, ModuleWorkSpaceType moduleWorkSpaceType = ModuleWorkSpaceType.BusinessModule)
        {
            ModuleName = pluginName;
            DisplayIndex = displayIndex;
            InitOnLoad = initOnLoad;
            BusinessName = businessName;
            ModuleWorkSpaceType = moduleWorkSpaceType;
            Tag = tag;
        }

        public string ModuleName { get; private set; }
        public bool InitOnLoad { get; set; }
        public int DisplayIndex { get; set; }
        public string SecurityCode { get; set; }
        public ModuleWorkSpaceType ModuleWorkSpaceType { get; private set; }
        public string BusinessName { get; private set; }
        public object Tag { get; set; }
    }

    [Flags]
    public enum ModuleWorkSpaceType
    {
        BusinessModule = 0,
        SettingsModule = 1,
        AutoTestingModule = 2
    }

    // ModuleWorkSpace的容器
    public interface IModuleWorkSpaceHost
    {
        void LoadModuleWorkSpace(IModuleWorkSpace autoTestModule);
        IModuleWorkSpace ActivingModule { get; set; }
        IModuleWorkSpace CreateModuleWorkSpace(Type type, ModuleWorkSpaceInfoAttribute attribute);
        void ClearEntranceButtons();
        void AddEntranceButton(string buttonText, IModuleWorkSpace linkedPlugin);
        void LoadFinish();
        void ActiveButton(object parameter);
    }

    public interface IModuleWorkSpace
    {
        ModuleWorkSpaceInfoAttribute ModuleWorkSpaceInfoAttribute { get; }
        IModuleWorkSpaceHost FormLoader { get; set; }
        void LoadModuleWorkSpace();
        void Run(object parameter);
        void BringToFrontEx(string plugName, FunctionInSettingType fst, AppliableFunctionType aft);
    }

    public static class ModuleWorkSpaceLoader
    {
        private static readonly List<IModuleWorkSpace> InnerBusinessModule = new List<IModuleWorkSpace>();
        public static List<IModuleWorkSpace> BusinessModule { get { return InnerBusinessModule; } }

        public static readonly Thread WorkerThread = new Thread(StartWorkerThread);
        public static bool NotifiedToQuite = false;

        private static IModuleWorkSpace _innerAutoTestingModule;
        public static IModuleWorkSpace AutoTestingModule { get { return _innerAutoTestingModule; } set { _innerAutoTestingModule = value; } }

        public static void BroadcastApplicationParameterChanged(/* Language Changed, Theme Changed, User Data Changed, ,,,*/)
        {
            foreach (IModuleWorkSpace moduleWorkSpace in BusinessModule)
            {
                //.....
            }
        }

        public static void BroadcastApplicationLanguageChanged(LangCode lanCode)
        {
            foreach (IModuleWorkSpace moduleWorkSpace in BusinessModule)
            {
                (moduleWorkSpace as _BaseModule).ChangeLanguage(lanCode);
            }
        }

        public static void BroadcastApplicationBringToFront(string plugName, FunctionInSettingType fst, AppliableFunctionType aft)
        {
            foreach (IModuleWorkSpace moduleWorkSpace in BusinessModule)
            {
                if (!moduleWorkSpace.ModuleWorkSpaceInfoAttribute.ModuleName.Equals(plugName)) continue;
                moduleWorkSpace.FormLoader.ActiveButton(fst);
                moduleWorkSpace.BringToFrontEx(plugName, fst, aft);
            }
        }

        public static bool BroadCastApplicationQuiting()
        {
            foreach (IModuleWorkSpace moduleWorkSpace in BusinessModule)
            {
            }
            if (WorkerThread.IsAlive)
                NotifiedToQuite = true;
            return NotifiedToQuite;
        }

        private static void StartWorkerThread(object formLoader)
        {
            var readFormLoader = (IModuleWorkSpaceHost)formLoader;
            BusinessModule.Clear();
            var files = Directory.GetFiles(Application.StartupPath + "\\plugins\\");
            foreach (string file in files)
            {
                var extName = Path.GetExtension(file);
                if (!string.Equals(extName, ".DLL", StringComparison.CurrentCultureIgnoreCase))
                    continue;

                var assembly = Assembly.LoadFile(file);
                var types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    var interfaces = type.GetInterfaces();
                    var isInterfaceValid = false;
                    foreach (Type interfaceType in interfaces)
                    {
                        if (interfaceType == typeof(IModuleWorkSpace) || interfaceType.BaseType == typeof(IModuleWorkSpace))
                        {
                            isInterfaceValid = true;
                            break;
                        }
                    }
                    var attributes = type.GetCustomAttributes(typeof(ModuleWorkSpaceInfoAttribute), false);
                    var isAttributeValid = false;
                    var isBusinessModule = false;
                    ModuleWorkSpaceInfoAttribute selectedAttribute = null;
                    foreach (var attribute in attributes)
                    {
                        if ((attribute is ModuleWorkSpaceInfoAttribute)) // &&  (attribute as ModuleWorkSpaceInfoAttribute).SecurityCode 
                        {
                            selectedAttribute = attribute as ModuleWorkSpaceInfoAttribute;
                            isAttributeValid = true;
                            isBusinessModule = selectedAttribute.ModuleWorkSpaceType == ModuleWorkSpaceType.BusinessModule || selectedAttribute.ModuleWorkSpaceType == ModuleWorkSpaceType.SettingsModule;
                        }
                    }
                    if (isInterfaceValid && isAttributeValid)
                    {
                        if (NotifiedToQuite)
                            return;
                        var plugIn = readFormLoader.CreateModuleWorkSpace(type, selectedAttribute);
                        if (plugIn != null)
                        {
                            if (isBusinessModule) // 常规业务模块和Settings类型的模块
                            {
                                BusinessModule.Add(plugIn);
                                if (selectedAttribute.InitOnLoad)
                                {
                                    //.....

                                }
                            }
                            else if (selectedAttribute.ModuleWorkSpaceType == ModuleWorkSpaceType.AutoTestingModule) // 附加模块，如自动化测试等
                                AutoTestingModule = plugIn;
                        }
                    }
                }
            }
            BusinessModule.Sort((p1, p2) => p1.ModuleWorkSpaceInfoAttribute.DisplayIndex - p2.ModuleWorkSpaceInfoAttribute.DisplayIndex);

            readFormLoader.ClearEntranceButtons();
            foreach (IModuleWorkSpace plugin in ModuleWorkSpaceLoader.BusinessModule)
            {
                var currentPlugin = plugin;
                currentPlugin.FormLoader = readFormLoader;
                readFormLoader.AddEntranceButton(plugin.ModuleWorkSpaceInfoAttribute.BusinessName, currentPlugin);
            }
            readFormLoader.LoadFinish();
        }

        public static void LoadPotentialModuleWorkSpaces(IModuleWorkSpaceHost formLoader)
        {
            WorkerThread.IsBackground = true;
            WorkerThread.SetApartmentState(ApartmentState.STA);
            WorkerThread.Start(formLoader);
        }
    }

}
