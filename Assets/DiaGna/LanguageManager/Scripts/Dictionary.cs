using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DiaGna.Freamwork.Language
{
    /// <summary>
    /// Represents a dictionary of words and their translations in different languages.
    /// </summary>
    [Serializable]
    public struct Dictionary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dictionary"/> struct using the specified array of words.
        /// </summary>
        /// <param name="words">The array of words to initialize the dictionary with.</param>
        public Dictionary(Word[] words)
        {
            this.words = words;
        }

        /// <summary>
        /// The array of words in the dictionary.
        /// </summary>
        public Word[] words;

        /// <summary>
        /// Represents a word in the dictionary.
        /// </summary>
        [Serializable]
        public struct Word
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Word"/> struct using the specified type, ID, and array of translations.
            /// </summary>
            /// <param name="type">The type of the word (text, image, or audio).</param>
            /// <param name="id">The ID of the word.</param>
            /// <param name="translations">The array of translations for the word.</param>
            public Word(WordType type, string id, Translation[] translations)
            {
                this.type = type;
                this.id = id;
                this.translations = translations;
            }

            public enum WordType
            {
                Text,
                Image,
                Audio
            }

            /// <summary>
            /// The type of the word (text, image, or audio).
            /// </summary>
            public WordType type;

            /// <summary>
            /// The ID of the word.
            /// </summary>
            public string id;

            /// <summary>
            /// The array of translations for the word.
            /// </summary>
            public Translation[] translations;

            /// <summary>
            /// Gets the translation for the specified language ID.
            /// </summary>
            /// <param name="languageId">The ID of the language to get the translation for.</param>
            /// <returns>The translation for the specified language ID.</returns>
            public Translation GetTranslation(string languageId)
            {
                foreach (var translation in translations)
                {
                    if (translation.languageId == languageId)
                    {
                        return translation;
                    }
                }
                return default;
            }

            /// <summary>
            /// Represents a translation of a word in a different language.
            /// </summary>
            [Serializable]
            public struct Translation
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="Translation"/> struct using the specified language ID and value.
                /// </summary>
                /// <param name="languageId">The ID of the language for the translation.</param>
                /// <param name="value">The value of the translation.</param>
                public Translation(string languageId, string value)
                {
                    this.languageId = languageId;
                    this.value = value;
                }

                /// <summary>
                /// The ID of the language for the translation.
                /// </summary>
                public string languageId;

                /// <summary>
                /// The value of the translation.
                /// </summary>
                public string value;
            }
        }
    }

#if UNITY_EDITOR

#endif
}