﻿// Copyright (c) Tier 3 Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. 

using ElasticLinq.Request.Criteria;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ElasticLinq.Test.Request.Criteria
{
    public class TermCriteriaTests
    {
        [Fact]
        public void NamePropertyIsTermWhenOneTerm()
        {
            var criteria = new TermCriteria("field", 1);

            Assert.Equal("term", criteria.Name);
            Assert.Equal(1, criteria.Values.Count);
        }

        [Fact]
        public void NamePropertyIsTermsWhenMultipleTerms()
        {
            var criteria = new TermCriteria("field", 1, 2);

            Assert.Equal("terms", criteria.Name);
            Assert.Equal(2, criteria.Values.Count);
        }

        [Fact]
        public void NamePropertyIsTermsWhenListOfTerms()
        {
            var criteria = TermCriteria.FromIEnumerable("field", new List<int> { 1, 2, 3 }.OfType<object>());
            Assert.Equal("terms", criteria.Name);
            Assert.Equal(3, criteria.Values.Count);
        }

        [Fact]
        public void ValuesAreNormalized()
        {
            var criteria = TermCriteria.FromIEnumerable("field", new List<int> { 1, 2, 1, 1, 2, 9 }.OfType<object>());

            Assert.Equal(3, criteria.Values.Count);
        }
    }
}