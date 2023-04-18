using DiaGna.Freamwork.Language;
using System.Collections.Generic;
using UnityEngine;

namespace DiaGna.Freamwork.Language
{
    /// <summary>
    /// Represents a database of words and their translations in different languages
    /// </summary>
    public class LanguageDatabase
    {
        // Private member variable that maps word ids to Dictionary.Word objects
        private readonly Dictionary<string, Dictionary.Word> m_Database;

        /// <summary>
        /// Constructor that initializes the database with a Dictionary object
        /// </summary>
        /// <param name="dictionary">The Dictionary object containing the words and their translations</param>
        public LanguageDatabase(Dictionary dictionary)
        {
            m_Database = new Dictionary<string, Dictionary.Word>();
            foreach (var word in dictionary.words)
            {
                Add(word);
            }
        }

        /// <summary>
        /// Constructor that initializes the database with a Dictionary object
        /// </summary>
        /// <param name="database">The Dictionaries containing the words and their translations</param>
        public LanguageDatabase(params Dictionary[] dictionaries)
        {
            m_Database = new Dictionary<string, Dictionary.Word>();
            foreach (var database in dictionaries)
            {
                foreach (var word in database.words)
                {
                    Add(word);
                }
            }
        }

        /// <summary>
        /// Adds a word to the database
        /// </summary>
        /// <param name="word">The Dictionary.Word object to add to the database</param>
        public void Add(Dictionary.Word word)
        {
            var key = word.id;
            if (m_Database.ContainsKey(key))
            {
                Debug.LogWarning($"The {key} is available now!");
            }
            else
            {
                m_Database.Add(key, word);
            }
        }

        /// <summary>
        /// Gets the translation of a word in a specified language
        /// </summary>
        /// <param name="key">The id of the word to translate</param>
        /// <param name="languageId">The LanguageId object representing the language to translate the word to</param>
        /// <returns>The translation of the word as a string</returns>
        public string GetWord(string key, LanguageId languageId)
        {
            return m_Database[key].GetTranslation(languageId.Id).value;
        }
    }
}