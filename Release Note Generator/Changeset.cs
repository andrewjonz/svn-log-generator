// -----------------------------------------------------------------------
// <copyright file="Changeset.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Release_Note_Generator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Changeset
    {
        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        /// <value>The filename.</value>
        public string Filename
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the change.
        /// </summary>
        /// <value>The type of the change.</value>
        public string ChangeType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the broken path.
        /// </summary>
        /// <value>The broken path.</value>
        public string BrokenPath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the full path.
        /// </summary>
        /// <value>The full path.</value>
        public string FullPath
        {
            get;
            set;
        }
    }
}
