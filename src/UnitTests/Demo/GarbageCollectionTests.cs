//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using System.Globalization;
//using System.IO;
//using System.Collections;
//using Vistron.Testing;

//namespace Demo
//{
//    public class GarbageCollectionTests
//    {
//        /// <summary>
//        /// Example of object getting garbage collected after all but the weak references are gone.
//        /// </summary>
//        [Fact]
//        public void GarbageCollectionTest()
//        {
//            // Reference ignored by GC
//            WeakReference weakReference = null;

//            WorkInDifferentScope(ref weakReference);

//            // Object is out of scope but not yet garbage collected
//            Assert.True(weakReference.IsAlive);

//            GC.Collect();
//            GC.WaitForPendingFinalizers();

//            // Object was correctly garbage collected
//            Assert.Null(weakReference.Target);
//            Assert.False(weakReference.IsAlive);
//        }

//        private void WorkInDifferentScope(ref WeakReference weakReference)
//        {
//            DemoObject demoObject = new DemoObject();

//            weakReference = new WeakReference(demoObject, true);
//            Assert.True(weakReference.IsAlive);

//            demoObject.Object = 15;
//        }

//        /// <summary>
//        /// Example of an element, that doesn't get garbage collected, since its reference is still alive in the parent method
//        /// </summary>
//        [Fact]
//        public void NotGarbageCollected()
//        {
//            // Reference ignored by GC
//            WeakReference weakReference = null;

//            object obj = WorkInDifferentScope2(ref weakReference);

//            Assert.True(weakReference.IsAlive);

//            GC.Collect();
//            GC.WaitForPendingFinalizers();

//            // Object was NOT garbage collected since obj references it
//            Assert.NotNull(weakReference.Target);
//            Assert.True(weakReference.IsAlive);
//        }

//        private object WorkInDifferentScope2(ref WeakReference weakReference)
//        {
//            DemoObject demoObject = new DemoObject();

//            weakReference = new WeakReference(demoObject, true);
//            Assert.True(weakReference.IsAlive);

//            demoObject.Object = 15;
//            return demoObject;
//        }
//    }
//}
