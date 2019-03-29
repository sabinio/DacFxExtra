﻿using Microsoft.SqlServer.Dac.Model;
//------------------------------------------------------------------------------
//<copyright company="Microsoft">
//
//    The MIT License (MIT)
//    
//    Copyright (c) 2015 Microsoft
//    
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//    
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
//    
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//</copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.SqlServer.Dac.Extensions.Prototype
{

    public interface ISqlSecurityPrincipal : ISqlModelElement { }

    public interface IServerSecurityPrincipal : ISqlSecurityPrincipal { }

    public interface ISqlDatabaseSecurityPrincipal : ISqlSecurityPrincipal, ISqlObjectAuthorizer{ }

    public sealed class UnresolvedISqlDatabaseSecurityPrincipalElement : TSqlModelElementReference, ISqlDatabaseSecurityPrincipal
    {
        public UnresolvedISqlDatabaseSecurityPrincipalElement(Model.ModelRelationshipInstance relationshipReference) : base(relationshipReference)
        {

        }
    }
    public interface ISqlSecurable : ISqlModelElement { }

    public sealed class UnresolvedISqlSecurableElement : TSqlModelElementReference, ISqlSecurable
    {
        public UnresolvedISqlSecurableElement(Model.ModelRelationshipInstance relationshipReference):base(relationshipReference)
        {  }
    }

    public interface ISpecifiesIndex : ISqlModelElement
    {
        IEnumerable<ISqlIndex> Indexes { get; }
    }

    public sealed class UnresolvedISpecifiesIndexElement: TSqlModelElementReference, ISpecifiesIndex
    {
        public UnresolvedISpecifiesIndexElement(Model.ModelRelationshipInstance instance)
            : base(instance)
        {
        }

        public IEnumerable<ISqlIndex> Indexes
        {
            get { throw new UnresolvedElementException(ModelMessages.UnresolvedObject); }
        }
    }

    public interface ISpecifiesDmlTrigger : ISqlModelElement
    {
        IEnumerable<TSqlDmlTrigger> Triggers { get; }
    }

    public interface ISqlColumnSource : ISqlModelElement 
    {
        IEnumerable<TSqlColumn> Columns { get; }        
    }
    public interface ISqlPromotedNodePath : ISqlModelElement { }

    public sealed class UnresolvedISqlPromotedNodePathElement : TSqlModelElementReference, ISqlPromotedNodePath
    {
        public UnresolvedISqlPromotedNodePathElement(Model.ModelRelationshipInstance relationshipReference)
            : base(relationshipReference)
        { }
    }

    public interface ISqlIndex : ISqlModelElement { }
    public interface ITableTypeConstraint : ISqlModelElement { }
    public interface IProtocolSpecifier : ISqlModelElement { }
    public interface IEndpointLanguageSpecifier : ISqlModelElement { }


    #region IExtendedProprtyHost
    public interface IExtendedPropertyHost : ISqlModelElement { }

    //TODO: Collect all extended property hosts. Some added but lots missing
    #endregion

    #region ISqlObjectAuthorizer
    public interface ISqlObjectAuthorizer : ISqlModelElement { }

    public sealed class UnresolvedISqlObjectAuthorizerElement : TSqlModelElementReference, ISqlObjectAuthorizer
    {
        public UnresolvedISqlObjectAuthorizerElement(Model.ModelRelationshipInstance relationshipReference) : base(relationshipReference)
        {

        }
    }

    // TODO: Collect all Authorizers
    #endregion

    public interface ISpecifiesStorage : ISqlModelElement
    {
        IEnumerable<TSqlDataCompressionOption> DataCompressionOptions { get; }

    }

    public interface ISqlDataType: ISqlModelElement
    {        
    }

    public sealed class UnresolvedISqlDataTypeElement : TSqlModelElementReference, ISqlDataType
    {
        public UnresolvedISqlDataTypeElement(Model.ModelRelationshipInstance relationshipReference)
            : base(relationshipReference)
        { }
    }
}

