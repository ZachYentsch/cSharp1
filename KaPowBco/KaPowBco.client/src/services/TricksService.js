import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class TricksService {
    async getAllTricks() {
        const res = await api.get('api/tricks')
        logger.log(res.data)
        AppState.tricks = res.data
        AppState.filteredTricks = res.data
    }

    async getTrickById(id) {
        const res = await api.get('api/tricks/' + id)
        logger.log(res.data)
        AppState.activeTrick = res.data
    }

    async createTrick(newTrick) {
        const res = await api.post('api/tricks', newTrick)
        logger.log(res.data)
        return res.data
    }

    async editTrick(updatedTrick, id) {
        const res = await api.put('api/tricks/' + id, updatedTrick)
        logger.log(res.data)
        AppState.activeTrick = new Trick(res.data)
    }

    async removeTrick(id) {
        const res = await api.delete('api/tricks/' + id)
        logger.log('Removed Trick', res.data)
        AppState.tricks = AppState.tricks.filter(t => t.id != t.id)
    }
}

export const tricksService = new TricksService()