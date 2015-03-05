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
using System.IO;

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
            class GhostDataFile : GhostDataGeneric
            {
                //string filePath;
                public GhostDataFile(string filepath)
                {
                    fileList = new List<GhostDataParseFile>();
                    fileIndex = 0;
                    fileList[fileIndex] = new GhostDataParseFile(filepath);
                }
                public GhostDataFile(string filepath, int mode)
                {
                    fileList = new List<GhostDataParseFile>();
                    fileIndex = 0;
                    fileList[fileIndex] = new GhostDataParseFile(filepath, mode);
                    if (mode == 2)
                    {
                        using (StreamReader sr = new StreamReader(filepath))
                        {
                            for (int i = 0; i > -1; i++)
                            {
                                fileList[fileIndex].lineList[i] = sr.ReadLine();
                                fileList[fileIndex].parsedCheck[i] = true;
                                if(sr.EndOfStream)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                public override GhostDataReturn fetch(int line)
                {
                    string resultString;
                    switch (fileList[fileIndex].fileMode)
                    {
                        case 0:
                            using (StreamReader sr = new StreamReader(fileList[fileIndex].filePath))
                            {
                                for (int i = 0; i < line; i++)
                                {
                                    try
                                    {
                                        sr.ReadLine();
                                    }
                                    catch (Exception e)
                                    {
                                        throw new Exceptions.EndOfFile("Line does not exist", e);
                                    }
                                }
                                try
                                {
                                    resultString = sr.ReadLine();
                                }
                                catch (Exception e)
                                {
                                    throw new Exceptions.EndOfFile("Line does not exist", e);
                                }
                            }
                            GhostDataReturn rtn0 = new GhostDataReturn(0, resultString);
                            return rtn0;
                        case 1:
                            GhostDataReturn rtn1 = new GhostDataReturn(0, "Nothing happened, the Generic namespace command was called");
                            if (fileList[fileIndex].parsedCheck[line])
                            {
                                rtn1 = new GhostDataReturn(0, "Nothing happened, the Generic namespace command was called");
                            }
                            else
                            {
                                rtn1 = new GhostDataReturn(0, "Nothing happened, the Generic namespace command was called");
                            }
                            return rtn1;
                        case 2:
                            GhostDataReturn rtn2;
                            string result;
                            try
                            {
                                result = fileList[fileIndex].lineList[line];
                            }
                            catch (Exception e)
                            {
                                throw new Exceptions.EndOfFile("Line does not exist", e);
                            }
                            rtn2 = new GhostDataReturn(0, result);
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
        class GhostDataGeneric
        {
            public int fileIndex;
            public List<GhostDataParseFile> fileList;
            public GhostDataGeneric()
            {

            }
            public virtual GhostDataReturn fetch(int line)
            {
                GhostDataReturn rtn = new GhostDataReturn(-1, "Nothing happened, the Generic namespace command was called");
                return rtn;
            }
            public virtual GhostDataReturn put()
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
                public FileNotIndexed(string message) : base(message)
                {

                }
                public FileNotIndexed(string message, Exception inner) : base(message, inner)
                {

                }
            }
            public class ReadError : System.Exception
            {
                public ReadError()
                {

                }
                public ReadError(string message) : base(message)
                {

                }
                public ReadError(string message, Exception inner) : base(message, inner)
                {

                }
            }
            public class EndOfFile : System.Exception
            {
                public EndOfFile()
                {

                }
                public EndOfFile(string message) : base(message)
                {

                }
                public EndOfFile(string message, Exception inner) : base(message, inner)
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
        struct GhostDataParseFile
        {
            public string filePath;
            public int fileMode;
            public List<string> lineList;
            public List<bool> parsedCheck;
            public GhostDataParseFile(string filepath)
            {
                filePath = filepath;
                fileMode = 0;
                lineList = new List<string>();
                parsedCheck = new List<bool>();
            }
            public GhostDataParseFile(string filepath, int filemode)
            {
                filePath = filepath;
                fileMode = filemode;
                lineList = new List<string>();
                parsedCheck = new List<bool>();
            }
        }
    }
}