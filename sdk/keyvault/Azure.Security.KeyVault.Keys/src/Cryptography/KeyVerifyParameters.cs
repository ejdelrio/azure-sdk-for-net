﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Text.Json;

namespace Azure.Security.KeyVault.Keys
{
    internal struct KeyVerifyParameters : IJsonSerializable
    {
        private static readonly JsonEncodedText AlgorithmPropertyNameBytes = JsonEncodedText.Encode("alg");
        private static readonly JsonEncodedText DigestPropertyNameBytes = JsonEncodedText.Encode("digest");
        private static readonly JsonEncodedText SignaturePropertyNameBytes = JsonEncodedText.Encode("value");

        public string Algorithm { get; set; }

        public byte[] Digest { get; set; }

        public byte[] Signature { get; set; }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            if (Algorithm != null)
            {
                json.WriteString(AlgorithmPropertyNameBytes, Algorithm);
            }
            if (Digest != null)
            {
                json.WriteString(DigestPropertyNameBytes, Base64Url.Encode(Digest));
            }
            if (Signature != null)
            {
                json.WriteString(SignaturePropertyNameBytes, Base64Url.Encode(Signature));
            }
        }
    }
}