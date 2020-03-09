﻿namespace TableTool
{
    using System;
    using System.Collections.Generic;

    public class Fx_fx : LocalBean
    {
        protected override bool ReadImpl()
        {
            this.FxID = base.readInt();
            this.Notes = base.readLocalString();
            this.Path = base.readLocalString();
            this.Node = base.readInt();
            return true;
        }

        public override string ToString()
        {
            System.Reflection.PropertyInfo[] properties = typeof(Fx_fx).GetProperties();
            List<string> strs = new List<string>();
            foreach (System.Reflection.PropertyInfo info in properties)
            {
                var val = info.GetValue(this);
                Type t = val.GetType();
                string str = string.Empty;
                if (t.IsArray)
                {
                    Array arr = val as Array;
                    object[] strList = new object[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        strList[i] = arr.GetValue(i);
                    }
                    str = string.Format(info.Name + ":{0}\n", string.Join(",", strList));
                }
                else
                {
                    str = string.Format(info.Name + ":{0}\n", val);
                }
                strs.Add(str);
            }
            return string.Join(" ", strs.ToArray());
        }

        public int FxID { get; private set; }

        public string Notes { get; private set; }

        public string Path { get; private set; }

        public int Node { get; private set; }
    }
}

