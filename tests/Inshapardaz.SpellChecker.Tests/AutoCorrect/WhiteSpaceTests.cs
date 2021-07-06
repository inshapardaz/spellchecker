using NUnit.Framework;

namespace Inshapardaz.SpellChecker.Tests.AutoCorrect
{
    public class WhiteSpaceTests
    {
        private void CheckResult(string input, string expectation)
        {
            var result = Checker.AutoCorrect(input);
            Assert.That(result, Is.EqualTo(expectation));
        }

        [Test]
        public void ShouldReplaceDoubleSpaces()
        {
            CheckResult("as f  ff    f", "as f ff f");
        }

        [Test]
        public void ShouldReplaceAllFullStops()
        {
            CheckResult("جس کا کام. اسی کو ساجھے...", "جس کا کام۔ اسی کو ساجھے۔۔۔");
        }

        [Test]
        public void ShouldReplaceAllCommas()
        {
            CheckResult("جس کا کام, اسی کو ساجھے...", "جس کا کام، اسی کو ساجھے۔۔۔");
        }

        [Test]
        public void ShouldReplaceAllSpaceBeforeCommans()
        {
            CheckResult("جس کا کام ، اسی کو ساجھے۔", "جس کا کام، اسی کو ساجھے۔");
        }

        [Test]
        public void ShouldReplaceLeadingAndTrailingSpaces()
        {
            CheckResult("   یہ تمام الفاظ میں خالی   جگہیں ہیں۔۔    ", "یہ تمام الفاظ میں خالی جگہیں ہیں۔۔");
        }

        [Test]
        public void ShouldReplaceLeadingAndTrailingSpacesInParagraph()
        {
            CheckResult(@"       ان پر ٹانگ رکھے بیٹھی رہتی تھی یا پھر شیشے کے سامنے بیٹھی بال سنوارتی تھی۔
ہیلن کی خوش اخلاقی اور سنس مکھ طبیت میری اور اس کی ماں کو ایک آنکھ نہ بھاتی، اس لیے اب وه اکثر خاموش ہی رہنے لگی تھی۔ لیکن جوں ہوں وہ بڑی سوتی گئی اور بھی زیادہ ثوب مشورت ہوتی گئی۔
ایک دن بیوہ نے اپنے آپ سے کہا جب تک بیان گھر میں مرد ہے میری بیٹی کی طرف تو کوئی دیکھے کیا کبھی نہیں ۔ سب ہین ہی کو دیکھنے آتے ہیں",
@"ان پر ٹانگ رکھے بیٹھی رہتی تھی یا پھر شیشے کے سامنے بیٹھی بال سنوارتی تھی۔
ہیلن کی خوش اخلاقی اور سنس مکھ طبیت میری اور اس کی ماں کو ایک آنکھ نہ بھاتی، اس لیے اب وه اکثر خاموش ہی رہنے لگی تھی۔ لیکن جوں ہوں وہ بڑی سوتی گئی اور بھی زیادہ ثوب مشورت ہوتی گئی۔
ایک دن بیوہ نے اپنے آپ سے کہا جب تک بیان گھر میں مرد ہے میری بیٹی کی طرف تو کوئی دیکھے کیا کبھی نہیں ۔ سب ہین ہی کو دیکھنے آتے ہیں");
        }
    }
}
