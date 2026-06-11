namespace Tests
{
    public class Tests
    {
        private FizzBuzzDetector _detector;

        [SetUp]
        public void Setup()
        {
            _detector = new FizzBuzzDetector();
        }

        [Test]
        public void Test_ProvidedExample()
        {
            var input = "Mary had a little lamb\nLittle lamb, little lamb\nMary had a little lamb\nIt's fleece was white as snow";
            var expectedOutput = "Mary had Fizz little Buzz\nFizz lamb, little Fizz\nBuzz had Fizz little lamb\nFizzBuzz fleece was Fizz as Buzz";
            var expectedCount = 9;

            var result = _detector.getOverlappings(input);

            Assert.That(result.Output, Is.EqualTo(expectedOutput));
            Assert.That(result.OverlapCount, Is.EqualTo(expectedCount));
        }


        [Test]
        public void Test_SingleString()
        {
            var input = "a a a a a a a a a";
            var expectedOutput = "a a Fizz a Buzz Fizz a a Fizz";
            var expectedCount = 4;

            var result = _detector.getOverlappings(input);

            Assert.That(result.Output, Is.EqualTo(expectedOutput));
            Assert.That(result.OverlapCount, Is.EqualTo(expectedCount));
        }


        [Test]
        public void Test_SingleWordInString()
        {
            var input = "a\na\na\na\na\na\na\na\na";
            var expectedOutput = "a\na\nFizz\na\nBuzz\nFizz\na\na\nFizz";
            var expectedCount = 4;

            var result = _detector.getOverlappings(input);

            Assert.That(result.Output, Is.EqualTo(expectedOutput));
            Assert.That(result.OverlapCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Test_allFizz()
        {
            var input = "Fizz Fizz Fizz Fizz Fizz Fizz Fizz Fizz Fizz";
            var expectedOutput = "Fizz Fizz Fizz Fizz Buzz Fizz Fizz Fizz Fizz";
            var expectedCount = 9;

            var result = _detector.getOverlappings(input);

            Assert.That(result.Output, Is.EqualTo(expectedOutput));
            Assert.That(result.OverlapCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Test_allBuzz()
        {
            var input = "Buzz Buzz Buzz Buzz Buzz Buzz Buzz Buzz Buzz";
            var expectedOutput = "Buzz Buzz Fizz Buzz Buzz Fizz Buzz Buzz Fizz";
            var expectedCount = 9;

            var result = _detector.getOverlappings(input);

            Assert.That(result.Output, Is.EqualTo(expectedOutput));
            Assert.That(result.OverlapCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Test_allFizzBuzz()
        {
            var input = "FizzBuzz FizzBuzz FizzBuzz FizzBuzz FizzBuzz FizzBuzz FizzBuzz FizzBuzz FizzBuzz";
            var expectedOutput = "FizzBuzz FizzBuzz Fizz FizzBuzz Buzz Fizz FizzBuzz FizzBuzz Fizz";
            var expectedCount = 9;

            var result = _detector.getOverlappings(input);

            Assert.That(result.Output, Is.EqualTo(expectedOutput));
            Assert.That(result.OverlapCount, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Test_FizzBuzz()
        {
            var input = "a a a a a a a a a a a a a a a a a";
            var expectedOutput = "a a Fizz a Buzz Fizz a a Fizz Buzz a Fizz a a FizzBuzz a a";

            var result = _detector.getOverlappings(input);

            Assert.That(result.Output.Split(" ")[14], Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void Test_InputIsNull()
        {
            var input = (string)null;

            Assert.Throws<ArgumentNullException>(() => _detector.getOverlappings(input));
        }

        [Test]
        public void Test_InputLengthUnderLimit()
        {
            var input = "a";

            Assert.Throws<ArgumentException>(() => _detector.getOverlappings(input));
        }

        [Test]
        public void Test_InputLengthOverLimit()
        {
            var input = new string('a', 101);

            Assert.Throws<ArgumentException>(() => _detector.getOverlappings(input));
        }

        [Test]
        public void Test_NonAlphanumericCharactersRemoved()
        {
            var input = "a, -  a! a, a a a a";
            var expectedOutput = "a, -  a! Fizz a Buzz Fizz a";
            var expectedCount = 3;

            var result = _detector.getOverlappings(input);

            Assert.That(result.Output, Is.EqualTo(expectedOutput));
            Assert.That(result.OverlapCount, Is.EqualTo(expectedCount));
        }

    }
}
