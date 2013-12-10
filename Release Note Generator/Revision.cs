// -----------------------------------------------------------------------
// <copyright file="Revision.cs" company="">
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
    public class Revision
    {
        /// <summary>
        /// Gets or sets the revision_ ID.
        /// </summary>
        /// <value>The revision_ ID.</value>
        public long Revision_ID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public string Date
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the added.
        /// </summary>
        /// <value>The added.</value>
        public List<string> Added
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>The modified.</value>
        public List<string> Modified
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the deleted.
        /// </summary>
        /// <value>The deleted.</value>
        public List<string> Deleted
        {
            get;
            set;
        }
    }
}
