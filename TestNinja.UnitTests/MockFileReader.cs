using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    public class MockFileReader : IFileReader
    {
        // it is a fake implementation, it doesnt access external resource as a File system for example
        // in order to be used by Unit Test class
        public string Read(string path)
        {
            return "";
        }
    }
}
