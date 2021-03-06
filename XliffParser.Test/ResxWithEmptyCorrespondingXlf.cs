﻿namespace XliffParser.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ResxWithEmptyCorrespondingXlf : TestSample
    {
        private static readonly string ResxContent =
        @"<?xml version=""1.0"" encoding=""utf-8""?>
<root>
  <xsd:schema id=""root"" xmlns="""" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"">
    <xsd:element name=""root"" msdata:IsDataSet=""true"">
      <xsd:complexType>
        <xsd:choice maxOccurs=""unbounded"">
          <xsd:element name=""data"">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />
                <xsd:element name=""comment"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""2"" />
              </xsd:sequence>
              <xsd:attribute name=""name"" type=""xsd:string"" msdata:Ordinal=""1"" />
              <xsd:attribute name=""UESanitized"" type=""xsd:boolean"" msdata:Ordinal=""3"" />
              <xsd:attribute name=""Visibility"" type=""Visibility_Type"" msdata:Ordinal=""4"" />
              <xsd:attribute name=""type"" type=""xsd:string"" msdata:Ordinal=""5"" />
              <xsd:attribute name=""mimetype"" type=""xsd:string"" msdata:Ordinal=""6"" />
            </xsd:complexType>
          </xsd:element>
          <xsd:element name=""resheader"">
            <xsd:complexType>
              <xsd:sequence>
                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />
              </xsd:sequence>
              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" />
            </xsd:complexType>
          </xsd:element>
        </xsd:choice>
      </xsd:complexType>
    </xsd:element>
    <xsd:simpleType name=""Visibility_Type"">
      <xsd:restriction base=""xsd:string"">
        <xsd:enumeration value=""Public"" />
        <xsd:enumeration value=""Obsolete"" />
        <xsd:enumeration value=""Private_OM"" />
      </xsd:restriction>
    </xsd:simpleType>
  </xsd:schema>
  <resheader name=""resmimetype"">
    <value>text/microsoft-resx</value>
  </resheader>
  <resheader name=""version"">
    <value>1.3</value>
  </resheader>
  <resheader name=""reader"">
    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <resheader name=""writer"">
    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>
  </resheader>
  <data name=""a"" UESanitized=""false"" Visibility=""Public"">
    <value>Text for a</value>
    <comment>Comment for a</comment>
  </data>
  <data name=""b"" UESanitized=""false"" Visibility=""Public"">
    <value>Text for b</value>
    <comment>Comment for b</comment>
  </data>
  <data name=""c"" UESanitized=""false"" Visibility=""Public"">
    <value>Text for c</value>
    <comment>Comment for c</comment>
  </data>
  <data name=""d"" UESanitized=""false"" Visibility=""Public"">
    <value>Text for d</value>
    <comment>Comment for d</comment>
  </data>
</root>";

        private static readonly string XlfContent =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<xliff version=""1.2"" xmlns=""urn:oasis:names:tc:xliff:document:1.2"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""urn:oasis:names:tc:xliff:document:1.2 xliff-core-1.2-transitional.xsd"">
  <file datatype=""xml"" source-language=""en"" target-language=""it"" original=""Strings.resx"">
    <body>
      <group id=""/RESOURCES/STRINGS.RESX"" datatype=""resx"" />
    </body>
  </file>
</xliff>";

        public ResxWithEmptyCorrespondingXlf()
            : base(ResxContent, XlfContent)
        {
        }
    }
}