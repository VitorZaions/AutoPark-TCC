﻿using System;
using System.Linq;
using System.Management;

namespace PDV.VIEW.App_Context
{
    public class MachineMonitor
    {

        private ConnectionOptions co = null;
        private ManagementScope ms = null;
        private ManagementObjectSearcher searcherMemRam = null;
        private ManagementObjectSearcher searcherCpu = null;
        private string machine = null;

        public MachineMonitor(string machine, string username = null, string userPassword = null)
        {
            this.machine = machine;

            if (co != null)
                co = null;

            if (ms != null)
                ms = null;

            if (searcherCpu != null)
                searcherCpu = null;

            if (searcherMemRam != null)
                searcherMemRam = null;

            co = new ConnectionOptions();
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(userPassword))
            {
                co.Username = username;
                co.Password = userPassword;
            }

            ms = new ManagementScope("\\\\" + machine + "\\root\\cimv2", co);
            ms.Options.EnablePrivileges = true;

            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            searcherMemRam = new ManagementObjectSearcher(ms, wql);

            ObjectQuery wql2 = new ObjectQuery("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");
            searcherCpu = new ManagementObjectSearcher(ms, wql2);
        }



        public long GetUsageCPUPercentage()
        {
            VerifyMachine();
            long result = 0;
            ManagementObject cpuTimes = searcherCpu.Get().Cast<ManagementObject>().FirstOrDefault();
            result = Convert.ToInt64(cpuTimes["PercentProcessorTime"]);
            return result;
        }

        public long GetUsageMemoryPercentage()
        {
            VerifyMachine();
            ManagementObjectCollection results = searcherMemRam.Get();
            long result = 0;
            foreach (ManagementObject res in results)
            {
                var totalVisibleMemorySize = Convert.ToInt64(res["TotalVisibleMemorySize"]);
                var freePhysicalMemory = Convert.ToInt64(res["FreePhysicalMemory"]);
                result = (100 - ((freePhysicalMemory * 100) / totalVisibleMemorySize));
            }

            return result;
        }

        private void VerifyMachine()
        {
            if (machine == null)
            {
                throw new Exception("Machine Name is not seting.");
            }
        }
    }
}