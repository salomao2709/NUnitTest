using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        Fundamentals.Stack<Object> stack;

        [SetUp]
        public void SetUp()
        {
            stack = new Fundamentals.Stack<Object>();
        }

        [Test]
        public void Push_WhenObjectParameterIsNull_ThrowsArgumentNullException()
        {
            Assert.That( () => stack.Push(null), Throws.Exception.TypeOf<ArgumentNullException>() );
        }

        [Test]
        public void Push_WhenObjectParameterIsValid_AddObjToStack()
        {
            Object obj = new Object();

            stack.Push(obj);

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenStackIsVoid_ThrowsInvalidOperationException()
        {
            Assert.That( () => stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>() );
        }

        [Test]
        public void Pop_WhenStackHasObjects_ReturnTheLasObjectFromStack()
        {
            Object obj1 = new Object();
            Object obj2 = new Object();
            stack.Push(obj1);
            stack.Push(obj2);

            Object result = stack.Pop();

            Assert.That(result, Is.EqualTo(obj2));
        }

        [Test]
        public void Pop_WhenStackHasObjects_RemoveTheLasObjectFromStack()
        {
            Object obj1 = new Object();
            Object obj2 = new Object();
            stack.Push(obj1);
            stack.Push(obj2);

            stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Peek_WhenStackIsVoid_ThrowsInvalidOperationException()
        {
            Assert.That( () => stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_WhenStackHasObjects_ReturnTheLastObjectFromStack()
        {
            Object obj1 = new Object();
            Object obj2 = new Object();
            stack.Push(obj1);
            stack.Push(obj2);

            Object result = stack.Peek();

            Assert.That(result, Is.EqualTo(obj2));
        }

        [Test]
        public void Peek_WhenStackHasObjects_DoesNotRemoveTheLastObjectFromStack()
        {
            Object obj1 = new Object();
            Object obj2 = new Object();
            stack.Push(obj1);
            stack.Push(obj2);

            stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(2));
        }

    }
}
