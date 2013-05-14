﻿//
// DuplicateSubmission.cs
//
// Author:
//       Jarl Erik Schmidt <github@jarlerik.com>
//
// Copyright (c) 2013 Jarl Erik Schmidt
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace Winterday.External.Gengo.Payloads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DuplicateSubmission
    {
        readonly Job _duplicateJob;
        readonly List<SubmittedJob> _existingJobs;
        readonly IReadOnlyList<SubmittedJob> _existingJobsRo;

        public Job DuplicateJob
        {
            get
            {
                return _duplicateJob;
            }
        }

        public IReadOnlyList<SubmittedJob> ExistingJobs
        {
            get
            {
                return _existingJobsRo;
            }
        }

        internal DuplicateSubmission(Job duplicateJob, IEnumerable<SubmittedJob> existingJobs)
        {
            if (duplicateJob == null)
                throw new ArgumentNullException("duplicateJob");

            if (existingJobs == null)
                throw new ArgumentNullException("existingJobs");

            _duplicateJob = duplicateJob;
            _existingJobs = existingJobs.ToList();

            _existingJobsRo = _existingJobs.AsReadOnly();
        }
    }
}
