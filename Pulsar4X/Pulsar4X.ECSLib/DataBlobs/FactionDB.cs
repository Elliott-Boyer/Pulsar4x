﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Pulsar4X.ECSLib
{
    public class FactionDB : BaseDataBlob
    {
        
        [JsonProperty]
        public List<Entity> Species { get; internal set; }

        
        [JsonProperty]
        public List<Guid> KnownSystems { get; internal set; }

        
        public ReadOnlyDictionary<Guid, List<Entity>> KnownJumpPoints => new ReadOnlyDictionary<Guid, List<Entity>>(InternalKnownJumpPoints);
        [JsonProperty]
        internal Dictionary<Guid, List<Entity>> InternalKnownJumpPoints = new Dictionary<Guid, List<Entity>>();

        
        [JsonProperty]
        public List<Entity> KnownFactions { get; internal set; }


        
        [JsonProperty]
        public List<Entity> Colonies { get; internal set; }

        
        [JsonProperty]
        public List<Entity> ShipClasses { get; internal set; }

        
        public ReadOnlyDictionary<Guid, Entity> ComponentDesigns => new ReadOnlyDictionary<Guid, Entity>(InternalComponentDesigns);
        [JsonProperty]
        internal Dictionary<Guid, Entity> InternalComponentDesigns = new Dictionary<Guid, Entity>();


        
        public ReadOnlyDictionary<Guid, Entity> MissileDesigns => new ReadOnlyDictionary<Guid, Entity>(InternalMissileDesigns);
        [JsonProperty]
        internal Dictionary<Guid, Entity> InternalMissileDesigns = new Dictionary<Guid, Entity>();

        public Entity Owner { get; set; }

        public FactionDB() : this(new List<Entity>(), new List<Guid>(), new List<Entity>(), new List<Entity>() ) { }

        public FactionDB(
            List<Entity> species,
            List<Guid> knownSystems,
            List<Entity> colonies,
            List<Entity> shipClasses)
        {
            Species = species;
            KnownSystems = knownSystems;
            Colonies = colonies;
            ShipClasses = shipClasses;
            KnownFactions = new List<Entity>();
            InternalComponentDesigns = new Dictionary<Guid, Entity>();
        }
        

        public FactionDB(FactionDB factionDB)
        {
            Species = new List<Entity>(factionDB.Species);
            KnownSystems = new List<Guid>(factionDB.KnownSystems);
            KnownFactions = new List<Entity>(factionDB.KnownFactions);
            Colonies = new List<Entity>(factionDB.Colonies);
            ShipClasses = new List<Entity>(factionDB.ShipClasses);

        }

        public override object Clone()
        {
            return new FactionDB(this);
        }

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            ((Game)context.Context).PostLoad += (sender, args) => { };
        }
    }
}