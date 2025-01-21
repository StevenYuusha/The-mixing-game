/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2024.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using UnityEngine;

namespace Leap.Examples
{
    public class SpawnObjectAtPosition : MonoBehaviour
    {
        public Transform objectToSpawn; // The prefab to spawn
        public Transform spawnPoint;    // The position to spawn the object at
        public Transform parent;        // The parent to assign the spawned object to

        public void SpawnObject()
        {
            // Spawn the object at the spawn point position and rotation
            Transform spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Set the parent of the spawned object if specified
            if (parent != null)
            {
                spawnedObject.SetParent(parent, true);
            }
        }
    }
}
