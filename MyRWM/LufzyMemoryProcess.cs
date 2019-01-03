using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace LufzyCSharpMemory
{
    class LufzyMemoryProcess
    {
        #region Process Control Center
        public static bool ProcessByName(string ProcName)
        {
            Process[] pname = Process.GetProcessesByName(ProcName);

            if (pname.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool ProcessByPID(int PID)
        {
            Process procid = Process.GetProcessById(PID);

            if (Convert.ToInt32(procid) != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Int32 GetProcessByPID(String proc)
        {
            Process[] ProcList;
            ProcList = Process.GetProcessesByName(proc);
            return ProcList[0].Id;
        }
        public static string GetPID(string ProcName)
        {
            var p = new Process();
            p.StartInfo.FileName = ProcName + ".exe";
            string ProcID = Convert.ToString(p.Id);

            if (ProcessByName(ProcName))
            {
                return ProcID;
            }
            else
            {
                return "Not Running!";
            }
        }
        public struct GetModule
        {
            public string moduleName;
            public int moduleAddress;
            public bool fp;
            public GetModule(string ProcName, string moduleName_)
            {
                moduleName = moduleName_;
                moduleAddress = 0x000000;

                try
                {
                    if (ProcessByName(ProcName))
                    {
                        Process[] p = Process.GetProcessesByName(ProcName);
                        foreach (ProcessModule m in p[0].Modules)
                        {
                            if (m.ModuleName == moduleName_)
                            {
                                moduleAddress = (Int32)m.BaseAddress;
                                fp = true;
                            }
                        }
                        fp = true;
                    }
                    else
                    {
                        fp = false;
                    }
                }
                catch
                {
                    fp = false;
                }
            }
        }
        #endregion
    }
}
