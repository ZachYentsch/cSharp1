// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getStorage, ref, uploadBytes } from "firebase/storage"
import { AppState } from "../AppState";
import { firebaseConfig } from "../env"
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";
// https://firebase.google.com/docs/web/setup#available-libraries

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const storage = getStorage(app);

class FirebaseService {
    async uploadFile(file, trick) {
        try {
            const userId = AppState.account.id
            const trickRef = ref(storage, `${userId}/${trick.name}/${file.name}`)
            const res = await uploadBytes(trickRef, file)
            return 'https://firebasestorage.googleapis.com/v0/b/kapoww-dfa96.appspot.com/o/' + trickRef.fullPath.replace(/\//ig, '%2F') + '?alt=media'
        } catch (error) {
            Pop.toast(error.message, 'error')
            logger.log(error)
        }
    }
}

export const firebaseService = new FirebaseService()