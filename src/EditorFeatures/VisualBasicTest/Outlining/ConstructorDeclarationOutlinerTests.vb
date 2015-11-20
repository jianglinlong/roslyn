' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports Microsoft.CodeAnalysis.Editor.Implementation.Outlining
Imports Microsoft.CodeAnalysis.Editor.VisualBasic.Outlining
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Namespace Microsoft.CodeAnalysis.Editor.VisualBasic.UnitTests.Outlining
    Public Class ConstructorDeclarationOutlinerTests
        Inherits AbstractVisualBasicSyntaxNodeOutlinerTests(Of SubNewStatementSyntax)

        Friend Overrides Function CreateOutliner() As AbstractSyntaxOutliner
            Return New ConstructorDeclarationOutliner()
        End Function

        <WpfFact, Trait(Traits.Feature, Traits.Features.Outlining)>
        Public Sub TestConstructor1()
            Const code = "
Class C1
    {|span:Sub $$New()
    End Sub|}
End Class
"
            Regions(code,
                Region("span", "Sub New() ...", autoCollapse:=True))
        End Sub

        <WpfFact, Trait(Traits.Feature, Traits.Features.Outlining)>
        Public Sub TestConstructor2()
            Const code = "
Class C1
    {|span:Sub $$New()
    End Sub|}                     
End Class
"
            Regions(code,
                Region("span", "Sub New() ...", autoCollapse:=True))
        End Sub

        <WpfFact, Trait(Traits.Feature, Traits.Features.Outlining)>
        Public Sub TestConstructor3()
            Const code = "
Class C1
    {|span:Sub $$New()
    End Sub|} ' .ctor
End Class
"
            Regions(code,
                Region("span", "Sub New() ...", autoCollapse:=True))
        End Sub

        <WpfFact, Trait(Traits.Feature, Traits.Features.Outlining)>
        Public Sub TestPrivateConstructor()
            Const code = "
Class C1
    {|span:Private Sub $$New()
    End Sub|}
End Class
"
            Regions(code,
                Region("span", "Private Sub New() ...", autoCollapse:=True))
        End Sub

        <WpfFact, Trait(Traits.Feature, Traits.Features.Outlining)>
        Public Sub TestConstructorWithComments()
            Const code = "
Class C1
    {|span1:'My
    'Constructor|}
    {|span2:Sub $$New()
    End Sub|}
End Class
"
            Regions(code,
                Region("span1", "' My ...", autoCollapse:=True),
                Region("span2", "Sub New() ...", autoCollapse:=True))
        End Sub

    End Class
End Namespace
