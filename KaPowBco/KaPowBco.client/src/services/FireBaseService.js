// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
    apiKey: "AIzaSyDlQKrwnPWRp1AN6iVlf6_-KBEtWuZgfQw",
    authDomain: "kapoww-dfa96.firebaseapp.com",
    projectId: "kapoww-dfa96",
    storageBucket: "kapoww-dfa96.appspot.com",
    messagingSenderId: "160731270056",
    appId: "1:160731270056:web:d62fa5bfdbf4c4d708ab9d",
    measurementId: "G-LMZ976M6P6"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);

class FirebaseService {
    async uploadFile(file, trick) {
        try {
            const userId = AppState.account.id
            const trickRef = ref(storage, `${userId}/${trick.name}/${file.name}`)
            const res = await uplodadBytes(trickRef, file)
            return 'https://firebasestorage.googleapis.com/v0/b/kapoww-dfa96.appspot.com/o/' + trickRef.fullPath.replace(/\//ig, '%2F') + '?alt=media'
        } catch (error) {
            Pop.toast(error.message, 'error')
            logger.log(error)
        }
    }
}

export const firebaseService = new FirebaseService()