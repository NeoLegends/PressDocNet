﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DocNetPress.Development.Generator.Extensions
{
    /// <summary>
    /// Allows an object to be used as type page element generator for DocNetPress
    /// </summary>
    public interface IPageElement
    {
        /// <summary>
        /// The PageElement's name
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Whether the element can output C# code or not
        /// </summary>
        bool SupportsCSharp { get; }

        /// <summary>
        /// Whether the element can output VB.NET code or not
        /// </summary>
        bool SupportsVBNET { get; }

        /// <summary>
        /// Whether the element can output F# code or not
        /// </summary>
        bool SupportsFSharp { get; }

        /// <summary>
        /// Whether the element can output JScript or not
        /// </summary>
        bool SupportsJScript { get; }

        /// <summary>
        /// Generates type documentation based on the given <see cref="System.Type"/>, the current documentation node, the output 
        /// language and optionally a given culture to generate the output in
        /// </summary>
        /// <param name="typeDetails">The <see cref="System.Type"/> for further information about the kind of type to be documented</param>
        /// <param name="documentationNode">The <see cref="System.Xml.XmlElement"/> containing all user-written documentation text</param>
        /// <param name="culture">The culture to generate the documentation in</param>
        /// <param name="language">In which language the generator is supposed to output the eventually generated code in</param>
        /// <returns>
        /// Valid HTML-Code ready to insert into a WordPress post or null if your <see cref="DocNetPress.Development.Generator.Extensions.IPageElement"/>
        /// is not able to parse the given input
        /// </returns>
        String GetTypeDocumentation(Type typeDetails, XmlElement documentationNode, OutputLanguage language, CultureInfo culture = null);

        /// <summary>
        /// Generates method documentation based on the given <see cref="System.Reflection.MethodInfo"/>, the current documentation node, the output 
        /// language and optionally a given culture to generate the output in
        /// </summary>
        /// <param name="typeDetails">The <see cref="System.Type"/> for further information about the method to be documented</param>
        /// <param name="documentationNode">The <see cref="System.Xml.XmlElement"/> containing all user-written documentation text</param>
        /// <param name="culture">The culture to generate the documentation in</param>
        /// <param name="language">In which language the generator is supposed to output the eventually generated code in</param>
        /// <returns>
        /// Valid HTML-Code ready to insert into a WordPress post or null if your <see cref="DocNetPress.Development.Generator.Extensions.IPageElement"/>
        /// is not able to parse the given input
        /// </returns>
        String GetMethodDocumentation(MethodInfo methodDetails, XmlElement documentationNode, OutputLanguage language, CultureInfo culture = null);

        /// <summary>
        /// Generates field documentation based on the given <see cref="System.Reflection.FieldInfo"/>, the current documentation node, the output 
        /// language and optionally a given culture to generate the output in
        /// </summary>
        /// <param name="fieldDetails">The <see cref="System.Reflection.FieldInfo"/> providing further information about the field to document</param>
        /// <param name="documentationNode">The <see cref="System.Xml.XmlElement"/> containing all user-written documentation text</param>
        /// <param name="culture">The culture to generate the documentation in</param>
        /// <param name="language">In which language the generator is supposed to output the eventually generated code in</param>
        /// <returns>
        /// Valid HTML-Code ready to insert into a WordPress post or null if your <see cref="DocNetPress.Development.Generator.Extensions.IPageElement"/>
        /// is not able to parse the given input
        /// </returns>
        String GetFieldDocumentation(FieldInfo fieldDetails, XmlElement documentationNode, OutputLanguage language, CultureInfo culture = null);

        /// <summary>
        /// Generates property documentation based on the given <see cref="System.Reflection.PropertyInfo"/>, the current documentation node, the output 
        /// language and optionally a given culture to generate the output in
        /// </summary>
        /// <param name="propertyDetails">Provides further information about the property to be documentated</param>
        /// <param name="documentationNode">The <see cref="System.Xml.XmlElement"/> containing all user-written documentation text</param>
        /// <param name="culture">The culture to generate the documentation in</param>
        /// <param name="language">In which language the generator is supposed to output the eventually generated code in</param>
        /// <returns>
        /// Valid HTML-Code ready to insert into a WordPress post or null if your <see cref="DocNetPress.Development.Generator.Extensions.IPageElement"/>
        /// is not able to parse the given input
        /// </returns>
        String GetPropertyDocumentation(PropertyInfo propertyDetails, XmlElement documentationNode, OutputLanguage language, CultureInfo culture = null);

        /// <summary>
        /// Generates event documentation based on the given <see cref="System.Reflection.EventInfo"/>, the current documentation node, the output 
        /// language and optionally a given culture to generate the output in
        /// </summary>
        /// <param name="eventDetails"><see cref="System.Reflection.EventInfo"/> containing further data about the event to document</param>
        /// <param name="documentationNode">The <see cref="System.Xml.XmlElement"/> containing all user-written documentation text</param>
        /// <param name="culture">The culture to generate the documentation in</param>
        /// <param name="language">In which language the generator is supposed to output the eventually generated code in</param>
        /// <returns>
        /// Valid HTML-Code ready to insert into a WordPress post or null if your <see cref="DocNetPress.Development.Generator.Extensions.IPageElement"/>
        /// is not able to parse the given input
        /// </returns>
        String GetEventDocumentation(EventInfo eventDetails, XmlElement documentationNode, OutputLanguage language, CultureInfo culture = null);

        /// <summary>
        /// Generates namespace documenation based on the namespace path, the current documentation node, the output language and optionally a given culture
        /// to generate the output in
        /// </summary>
        /// <param name="nameSpace">The full name / path of the namespace</param>
        /// <param name="documentationNode">The <see cref="System.Xml.XmlElement"/> containing all user-written documentation text</param>
        /// <param name="culture">The culture to generate the documentation in</param>
        /// <param name="language">In which language the generator is supposed to output the eventually generated code in</param>
        /// <returns>
        /// Generated HTML-Code from the given documentation node or null if your <see cref="DocNetPress.Development.Generator.Extensions.IPageElement"/>
        /// is not able to parse the given input
        /// </returns>
        String GetNamespaceDocumentation(String nameSpace, XmlElement documentationNode, OutputLanguage language, CultureInfo culture = null);

        /// <summary>
        /// This method is fired when there's a reference inside the XML documentation code the compiler couldn't resolve at compile time, so it's not determined what
        /// the documentated element actually is. (It can be a type, field, property, event, etc) I leave it up to you to deal with those cases
        /// </summary>
        /// <param name="assemblyPath">The path to the assembly the documentation code belongs to</param>
        /// <param name="fullMemberName">The full name of the member that failed to document</param>
        /// <param name="documentationNode">The <see cref="System.Xml.XmlElement"/> containing all user-written documentation text</param>
        /// <param name="culture">The culture to generate the documentation in</param>
        /// <param name="language">In which language the generator is supposed to output the eventually generated code in</param>
        /// <returns>
        /// Generated HTML-Code from the given documentation node or null if your <see cref="DocNetPress.Development.Generator.Extensions.IPageElement"/>
        /// is not able to parse the given input
        /// </returns>
        String GetErrorDocumentation(String assemblyPath, String fullMemberName, XmlElement documentationNode, OutputLanguage language, CultureInfo culture = null);
    }
}
