﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Test
    {
        string SubjectName;
        bool SubjectResult;

        public string Name
        {
            get
            {
                return SubjectName;
            }
            set
            {
                SubjectName = value;
            }
        }

        public bool Result
        {
            get
            {
                return SubjectResult;
            }
            set
            {
                SubjectResult = value;
            }
        }

        public Test()
        {
            SubjectName = "Subject";
            SubjectResult = false;
        }

        public Test(string name, bool result)
        {
            SubjectName = name;
            SubjectResult = result;
        }

        public override string ToString()
        {
            return SubjectName + " " + SubjectResult.ToString() + " ";
        }
    }
}
