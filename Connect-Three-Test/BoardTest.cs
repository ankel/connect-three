using Connect_Three;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Connect_Three_Test
{
    
    
    /// <summary>
    ///This is a test class for BoardTest and is intended
    ///to contain all BoardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BoardTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Board target = new Board(); // TODO: Initialize to an appropriate value
            string expected = @". . . 
. . . 
. . . 
. . . 
"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.ToString();
            Assert.IsTrue(expected == actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Score
        ///</summary>
        [TestMethod()]
        public void ScoreTest()
        {
            {
                Board target = new Board(); // TODO: Initialize to an appropriate value
                target.board = new char[,] 
                    {   { 'a', 'a', 'a' }, 
                        { '.', '.', '.' }, 
                        { '.', '.', '.' }, 
                        { '.', '.', '.' } };
                char side = 'a'; // TODO: Initialize to an appropriate value
                int expected = Board.Win; // TODO: Initialize to an appropriate value
                int actual;
                actual = target.Score(side, false);
                Assert.AreEqual(expected, actual);
                //Assert.Inconclusive("Verify the correctness of this test method.");
            }

            {
                Board target = new Board(); // TODO: Initialize to an appropriate value
                target.board = new char[,] 
                    {   { 'a', '.', '.' }, 
                        { '.', 'a', '.' }, 
                        { '.', '.', 'a' }, 
                        { '.', '.', '.' } };
                char side = 'b'; // TODO: Initialize to an appropriate value
                int expected = Board.Lose; // TODO: Initialize to an appropriate value
                int actual;
                actual = target.Score(side, false);
                Assert.AreEqual(expected, actual);
                //Assert.Inconclusive("Verify the correctness of this test method.");
            }

            {
                Board target = new Board(); // TODO: Initialize to an appropriate value
                target.board = new char[,] 
                    {   { 'a', '.', '.' }, 
                        { 'a', '.', '.' }, 
                        { 'a', '.', '.' }, 
                        { '.', '.', '.' } };
                char side = 'a'; // TODO: Initialize to an appropriate value
                int expected = Board.Win; // TODO: Initialize to an appropriate value
                int actual;
                actual = target.Score(side, false);
                Assert.AreEqual(expected, actual);
                //Assert.Inconclusive("Verify the correctness of this test method.");
            }

            {
                Board target = new Board(); // TODO: Initialize to an appropriate value
                target.board = new char[,] 
                    {   { '.', '.', 'a' }, 
                        { '.', 'a', '.' }, 
                        { 'a', '.', '.' }, 
                        { '.', '.', '.' } };
                char side = 'b'; // TODO: Initialize to an appropriate value
                int expected = Board.Lose; // TODO: Initialize to an appropriate value
                int actual;
                actual = target.Score(side, false);
                Assert.AreEqual(expected, actual);
                //Assert.Inconclusive("Verify the correctness of this test method.");
            }

            {
                Board target = new Board(); // TODO: Initialize to an appropriate value
                target.board = new char[,] 
                    {   { 'a', 'a', '.' }, 
                        { 'a', 'a', '.' }, 
                        { '.', '.', '.' }, 
                        { '.', '.', '.' } };
                char side = 'a'; // TODO: Initialize to an appropriate value
                int expected = 5; // TODO: Initialize to an appropriate value
                int actual;
                actual = target.Score(side, true);
                Assert.AreEqual(expected, actual);
                //Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for Drop
        ///</summary>
        [TestMethod()]
        public void DropTest()
        {
            {
                Board target = new Board(); // TODO: Initialize to an appropriate value
                target.board = new char[,] 
                    {   { 'a', 'a', '.' }, 
                        { 'a', 'a', '.' }, 
                        { '.', '.', '.' }, 
                        { 'a', '.', '.' } };
                int col = 0; // TODO: Initialize to an appropriate value
                char side = 'a'; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.Drop(col, side);
                Assert.AreEqual(expected, actual);
                //Assert.Inconclusive("Verify the correctness of this test method.");
            }

            {
                Board target = new Board(); // TODO: Initialize to an appropriate value
                target.board = new char[,] 
                    {   { 'a', 'a', '.' }, 
                        { 'a', 'a', '.' }, 
                        { '.', '.', '.' }, 
                        { 'a', 'a', 'a' } };
                int col = 0; // TODO: Initialize to an appropriate value
                char side = 'a'; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.Drop(col, side);
                Assert.AreEqual(expected, actual);
                //Assert.Inconclusive("Verify the correctness of this test method.");
            }

            {
                Board target = new Board(); // TODO: Initialize to an appropriate value
                target.board = new char[,] 
                    {   { 'a', 'a', '.' }, 
                        { 'a', 'a', '.' }, 
                        { '.', '.', '.' }, 
                        { 'a', '.', '.' } };
                int col = 1; // TODO: Initialize to an appropriate value
                char side = 'a'; // TODO: Initialize to an appropriate value
                bool expected = true; // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.Drop(col, side);
                Assert.AreEqual(expected, actual);
                Assert.AreEqual('a', target.board[2, 1]);
                //Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }
    }
}
