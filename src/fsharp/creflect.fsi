// Copyright (c) Microsoft Open Technologies, Inc.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

module internal Microsoft.FSharp.Compiler.QuotationTranslator
open Microsoft.FSharp.Compiler 

// Convert quoted TAST data structures to structures ready for pickling 

open Microsoft.FSharp.Compiler.Tast
open Microsoft.FSharp.Compiler.Tastops

[<Sealed>]
type QuotationTranslationEnv =
   static member Empty : QuotationTranslationEnv
   member BindTypars : Typars -> QuotationTranslationEnv

exception InvalidQuotedTerm of exn
exception IgnoringPartOfQuotedTermWarning of string * Range.range

[<RequireQualifiedAccess>]
type IsReflectedDefinition =
|   Yes
|   No
val ConvExprPublic : Env.TcGlobals * Import.ImportMap * CcuThunk * IsReflectedDefinition -> QuotationTranslationEnv -> Expr -> TType list * Expr list * QuotationPickler.ExprData 
val ConvMethodBase  : Env.TcGlobals * Import.ImportMap * CcuThunk -> QuotationTranslationEnv ->  string * Val  -> QuotationPickler.MethodBaseData


