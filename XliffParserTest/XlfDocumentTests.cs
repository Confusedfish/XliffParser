﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XliffParserTest;

namespace xlflib.Tests
{
    [TestClass()]
    public class XlfDocumentTests
    {
        [TestMethod()]
        public void UpdateEmptyXlfFromResx()
        {
            using (var sample = new ResxWithEmptyCorrespondingXlf())
            {
                var xlfDocument = new XlfDocument(sample.XlfFileName);
                var updateResult = xlfDocument.UpdateFromResX(sample.ResxFileName);

                Assert.AreEqual(0, updateResult.Item1);
                Assert.AreEqual(4, updateResult.Item2);
                Assert.AreEqual(0, updateResult.Item3);

                var xlfTransUnits = xlfDocument.Files.SelectMany(f => f.TransUnits).ToDictionary(tu => tu.Id, tu => tu);

                Assert.AreEqual(4, xlfTransUnits.Count);

                AssertTranslationUnit(xlfTransUnits, "a", "Text for a", "Text for a", "Comment for a", "new");
                AssertTranslationUnit(xlfTransUnits, "b", "Text for b", "Text for b", "Comment for b", "new");
                AssertTranslationUnit(xlfTransUnits, "c", "Text for c", "Text for c", "Comment for c", "new");
                AssertTranslationUnit(xlfTransUnits, "d", "Text for d", "Text for d", "Comment for d", "new");
            }
        }

        [TestMethod()]
        public void UpdateStaleXlfFromResx()
        {
            using (var sample = new ResxWithStaleCorrespondingXlf())
            {
                var xlfDocument = new XlfDocument(sample.XlfFileName);
                var updateResult = xlfDocument.UpdateFromResX(sample.ResxFileName);

                Assert.AreEqual(2, updateResult.Item1);
                Assert.AreEqual(1, updateResult.Item2);
                Assert.AreEqual(1, updateResult.Item3);

                var xlfTransUnits = xlfDocument.Files.SelectMany(f => f.TransUnits).ToDictionary(tu => tu.Id, tu => tu);

                Assert.AreEqual(4, xlfTransUnits.Count);

                AssertTranslationUnit(xlfTransUnits, "a", "Text for a", "Translation", "Comment for a", null);
                AssertTranslationUnit(xlfTransUnits, "b", "Text for b", "Translation", "Comment for b", "new");
                AssertTranslationUnit(xlfTransUnits, "c", "Text for c", "Translation", "Comment for c", "new");
                AssertTranslationUnit(xlfTransUnits, "d", "Text for d", "Text for d", "Comment for d", "new");
            }
        }

        private static void AssertTranslationUnit(Dictionary<string, XlfTransUnit> xlfTransUnits, string id, string source, string target, string comment, string targetState)
        {
            Assert.IsTrue(xlfTransUnits.ContainsKey(id));
            var unit = xlfTransUnits[id];

            Assert.AreEqual(source, unit.Source);
            Assert.AreEqual(target, unit.Target);
            Assert.IsTrue(unit.Optional.Notes.Any());
            Assert.AreEqual(comment, unit.Optional.Notes.First().Value);
            Assert.AreEqual(targetState ?? string.Empty, unit.Optional.TargetState);
        }
    }
}