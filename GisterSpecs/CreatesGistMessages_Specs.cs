﻿using EchelonTouchInc.Gister.Api;
using NUnit.Framework;
using Should.Fluent;

namespace GisterSpecs
{
    [TestFixture]
    public class CreatesGistMessages_Specs
    {
        [Test]
        public void ShouldEncodeMessagesAsJson()
        {
            new CreatesGistMessages().CreateMessage("myfile.cs", "Some super sweet gistiness","description",false).Should().Equal(
                @"{
  ""public"": true,
  ""files"": {
    ""myfile.cs"": {
      ""content"": ""Some super sweet gistiness""
    }
  } 
}");

        }

    }
}
