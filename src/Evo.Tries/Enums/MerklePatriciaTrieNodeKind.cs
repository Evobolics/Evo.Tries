﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo.Enums
{
    public enum MerklePatriciaTrieNodeKind
    {
        /// <summary>
        /// A node of an unknown type.  This prevents zero, non-initialized information from meaning something.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// A 17-item node.  Of the 17 items, one index is used to store
        /// each of the possible value held by the next hex character (nibble)
        /// in the path, and one is used to hold the final target value , given
        /// the case that the path has been fully traversed.
        /// </summary>
        Branch = 1,

        /// <summary>
        /// An extension node is a two-item node that stores a key and a value.  
        /// Extension nodes make it more efficient to store key value pairs with long keys. 
        /// To store a 256 bit key, requires a 64 bit character path.  With such a path
        /// it is inevitable that after traversing the first few layers of the trie, a node will be 
        /// reached where no divergent path exists for at least part, if not the rest of the way down. 
        /// It would be naive, and inefficient to require all of these non branching nodes
        /// to have empty values in every index, one for each of the 16 hex characters besides
        /// the target index, with the target index being the next nibble in the path. 
        /// To improve the efficiency of the trie, a shortcut node can be added to shortcut the decent
        /// by setting up an extension node of the form  (encodedPath, key), where encodedPath contains
        /// the “partial path” to skip ahead, and the key is for the next lookup.
        /// </summary>
        Extension = 2,

        /// <summary>
        /// A final two-item node that stores a value.  A value node is like a leaf node, except that the indicator that it is a leaf is encoded
        /// into the firt nibble of the encoded skip ahead path, and the value is the target value. 
        /// </summary>
        Leaf = 3
    }
}
