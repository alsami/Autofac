﻿// This software is part of the Autofac IoC container
// Copyright © 2007 - 2008 Autofac Contributors
// https://autofac.org
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using Autofac.Core;

namespace Autofac.Features.Metadata
{
    /// <summary>
    /// Support the <see cref="Meta{T}"/>
    /// types automatically whenever type T is registered with the container.
    /// Metadata values come from the component registration's metadata.
    /// </summary>
    internal class MetaRegistrationSource : ImplicitRegistrationSource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaRegistrationSource"/> class.
        /// </summary>
        public MetaRegistrationSource()
            : base(typeof(Meta<>))
        {
        }

        /// <inheritdoc/>
        public override string Description => MetaRegistrationSourceResources.MetaRegistrationSourceDescription;

        /// <inheritdoc/>
        protected override object ResolveInstance<T>(IComponentContext ctx, ResolveRequest request)
            => new Meta<T>((T)ctx.ResolveComponent(request), request.Registration.Target.Metadata);
    }
}
