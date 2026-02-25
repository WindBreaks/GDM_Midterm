using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AssignmentSystem.Services;
using System;

namespace Assignment
{
    public class Assignment_Testcase
    {
        private IAssignment assignment;

        [SetUp]
        public void Setup()
        {
            // Reset static state before each test
            AssignmentDebugConsole.Clear();

            // Use StudentSolution as the test subject
            assignment = new StudentSolution();
        }

        [TearDown]
        public void Teardown()
        {
            if (assignment is MonoBehaviour)
            {
                MonoBehaviour.DestroyImmediate(assignment as MonoBehaviour);
            }
        }

        #region Midterm Exam

        [Category("Midterm")]
        [TestCase]
        public void EXAM01_FindWords_Pattern01()
        {
            string[,] board = new string[,]
            {
                { "o", "a", "a", "n" },
                { "e", "t", "a", "e" },
                { "i", "h", "k", "r" },
                { "i", "f", "l", "v" }
            };

            string[] words = new string[] { "oath", "pea", "eat", "rain" };
            assignment.EXAM01_FindWords(board, words);
            string[] expected = new string[] { "oath", "eat" };

            string output = AssignmentDebugConsole.GetOutput().Trim();
            string[] actual = output.Split("\n").Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            Assert.AreEqual(expected.Length, actual.Length);
            foreach (var word in expected)
            {
                Debug.Log($"Checking for expected word: {word}");
                if (!actual.Contains(word))
                {
                    Assert.Fail($"Expected found word should be \n{string.Join('\n', expected)}\nBut actual output is \n{string.Join('\n', actual)}");
                }
            }
        }

        [Category("Midterm")]
        [TestCase]
        public void EXAM01_FindWords_Pattern02()
        {
            string[,] board = new string[,]
            {
                { "a", "b" },
                { "c", "d" }
            };

            string[] words = new string[] { "abcb" };
            assignment.EXAM01_FindWords(board, words);
            string[] expected = new string[] { };

            string output = AssignmentDebugConsole.GetOutput().Trim();
            string[] actual = output.Split("\n").Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            Assert.AreEqual(expected.Length, actual.Length);
            foreach (var word in expected)
            {
                Debug.Log($"Checking for expected word: {word}");
                if (!actual.Contains(word))
                {
                    Assert.Fail($"Expected found word should be \n{string.Join('\n', expected)}\nBut actual output is \n{string.Join('\n', actual)}");
                }
            }
        }

        [Category("Midterm")]
        [TestCase]
        public void EXAM01_FindWords_Pattern03()
        {
            string[,] board = new string[,]
            {
                { "a", "b", "c" },
                { "a", "e", "d" },
                { "a", "f", "g" }
            };

            string[] words = new string[] { "abcdefg" };
            assignment.EXAM01_FindWords(board, words);
            string[] expected = new string[] { "abcdefg" };

            string output = AssignmentDebugConsole.GetOutput().Trim();
            string[] actual = output.Split("\n").Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            Assert.AreEqual(expected.Length, actual.Length);
            foreach (var word in expected)
            {
                Debug.Log($"Checking for expected word: {word}");
                if (!actual.Contains(word))
                {
                    Assert.Fail($"Expected found word should be \n{string.Join('\n', expected)}\nBut actual output is \n{string.Join('\n', actual)}");
                }
            }
        }

        [Category("Midterm")]
        [TestCase]
        public void EXAM01_FindWords_Pattern04()
        {
            string[,] board = new string[,]
            {
                { "a", "b", "c", "e" },
                { "s", "f", "c", "s" },
                { "a", "d", "e", "e" }
            };

            string[] words = new string[] { "see", "abcced", "abcb" };
            assignment.EXAM01_FindWords(board, words);
            string[] expected = new string[] { "see", "abcced" };

            string output = AssignmentDebugConsole.GetOutput().Trim();
            string[] actual = output.Split("\n").Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            Assert.AreEqual(expected.Length, actual.Length);
            foreach (var word in expected)
            {
                Debug.Log($"Checking for expected word: {word}");
                if (!actual.Contains(word))
                {
                    Assert.Fail($"Expected found word should be \n{string.Join('\n', expected)}\nBut actual output is \n{string.Join('\n', actual)}");
                }
            }
        }

        [Category("Midterm")]
        [TestCase]
        public void EXAM01_FindWords_Pattern05()
        {
            string[,] board = new string[,]
            {
                { "t", "h", "i", "s", "i", "s", "a" },
                { "s", "i", "m", "p", "l", "e", "w" },
                { "i", "m", "p", "l", "e", "x", "o" },
                { "l", "i", "f", "e", "s", "t", "r" },
                { "l", "d", "a", "n", "u", "y", "d" },
                { "y", "r", "f", "m", "l", "p", "m" },
                { "e", "a", "s", "y", "r", "e", "a" },
                { "w", "o", "r", "l", "d", "s", "l" },
                { "b", "i", "g", "t", "e", "s", "t" },
                { "c", "o", "m", "p", "l", "e", "x" }
            };

            string[] words = new string[] {
                "this", "simple", "life", "world", "test", "complex",
                "impossible", "verylongwordthatdoesnotexist", "xyz",
                "word", "big", "easy", "hard", "path", "grid",
                "thi", "sim", "wor", "tes", "com", "pat", "row", "col"
            };
            assignment.EXAM01_FindWords(board, words);
            string[] expected = new string[] {
                "this",
                "simple",
                "life",
                "world",
                "test",
                "complex",
                "word",
                "big",
                "easy",
                "thi",
                "sim",
                "wor",
                "tes",
                "com",
                "row",
            };

            string output = AssignmentDebugConsole.GetOutput().Trim();
            string[] actual = output.Split("\n").Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            Assert.AreEqual(expected.Length, actual.Length);
            foreach (var word in expected)
            {
                Debug.Log($"Checking for expected word: {word}");
                if (!actual.Contains(word))
                {
                    Assert.Fail($"Expected found word should be \n{string.Join('\n', expected)}\nBut actual output is \n{string.Join('\n', actual)}");
                }
            }
        }


        #endregion
    }

    public class TestUtils
    {
        internal static void AssertMultilineEqual(string expected, string actual, string message = null)
        {
            string normExpected = expected.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            string normActual = actual.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            if (string.IsNullOrEmpty(message))
            {
                message = $"Expected output:\n{normExpected}\n----\nActual output:\n{normActual}";
            }
            Assert.AreEqual(normExpected, normActual, message);
        }
    }

}