//////////////////////////////////////////////
// Copyright Joshua Zenn 2015               //
// Protected by propietary licensing. See   //
// https://github.com/ARMmaster17/GhostData //
// for more details and to obtain           //
// sublicensing for your project            //
//////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghost
{
    namespace GhostData
    {/*
    namespace XML
    {
        public class GhostDataXML : GhostDataGeneric
        {
            public GhostDataXML()
            {
                
            }
            public override GhostDataReturn fetch()
            {
                return null;
            }
            public override GhostDataReturn put()
            {
                return 0;
            }
        }
    }
    namespace SQL
    {
        public class GhostDataSQL : GhostDataGeneric
        {
            public GhostDataSQL()
            {

            }
            public override GhostDataReturn fetch()
            {
                return null;
            }
            public override GhostDataReturn put()
            {
                return 0;
            }
        }
    }*/
        namespace File
        {
            public class GhostDataFile : GhostDataGeneric
            {
                string filePath;
                public GhostDataFile(string filepath)
                {
                    fileIndex = 0;
                }
                public GhostDataFile(string filepath, int mode)
                {

                }
                public override GhostDataReturn fetch(int line)
                {
                    switch (fileList[fileIndex].fileMode)
                    {
                        case 0:
                            GhostDataReturn rtn0 = new GhostDataReturn(0, "Nothing happened, the Generic namespace command was called");
                            return rtn0;
                        case 1:
                            GhostDataReturn rtn1 = new GhostDataReturn(0, "Nothing happened, the Generic namespace command was called");
                            return rtn1;
                        case 2:
                            GhostDataReturn rtn2;
                            if (fileList[fileIndex].parsedCheck[line])
                            {
                                rtn2 = new GhostDataReturn(0, "Nothing happened, the Generic namespace command was called");
                            }
                            else
                            {
                                rtn2 = new GhostDataReturn(0, "Nothing happened, the Generic namespace command was called");
                            }
                            return rtn2;
                        default:
                            GhostDataReturn rtn = new GhostDataReturn(0, "Nothing happened, the Generic namespace command was called");
                            return rtn;
                    }
                }
                public override GhostDataReturn put()
                {
                    GhostDataReturn rtn = new GhostDataReturn(0, "Nothing happened, the Generic namespace command was called");
                    return rtn;
                }
            }
        }
        private class GhostDataGeneric
        {
            public int fileIndex;
            public List<GhostDataParseFile> fileList;
            public GhostDataGeneric()
            {

            }
            public GhostDataReturn fetch()
            {
                GhostDataReturn rtn = new GhostDataReturn(-1, "Nothing happened, the Generic namespace command was called");
                return rtn;
            }
            public GhostDataReturn put()
            {
                GhostDataReturn rtn = new GhostDataReturn(-1, "Nothing happened, the Generic namespace command was called");
                return rtn;
            }
            public GhostDataReturn switchFile(int index)
            {
                int prevIndex;
                prevIndex = fileIndex;
                fileIndex = index;
                try
                {
                    GhostDataParseFile GDPF = fileList[index];
                }
                catch (Exception e)
                {
                    fileIndex = prevIndex;
                    throw new Exceptions.FileNotIndexed("File has not yet been indexed by GhostData", e);
                }
                GhostDataReturn rtn = new GhostDataReturn(0, "File switched");
                return rtn;
            }
        }
        namespace Exceptions
        {
            public class FileNotIndexed : System.Exception
            {
                public FileNotIndexed()
                {

                }
                public FileNotIndexed(string message)
                    : base(message)
                {

                }
                public FileNotIndexed(string message, Exception inner)
                    : base(message, inner)
                {

                }
            }
            public class ReadError : System.Exception
            {
                public ReadError()
                {

                }
                public ReadError(string message)
                    : base(message)
                {

                }
                public ReadError(string message, Exception inner)
                    : base(message, inner)
                {

                }
            }
        }
        public struct GhostDataReturn
        {
            public readonly int errorCode;
            public readonly string content;
            public GhostDataReturn(int ec, string ct)
            {
                errorCode = ec;
                content = ct;
            }
        }
        private struct GhostDataParseFile
        {
            public string filePath;
            public int fileMode;
            public List<string> lineList;
            public List<bool> parsedCheck;
        }
    }
}