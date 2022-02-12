import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import { api } from './AxiosService';

class CoachingsService {
    async getCoachings(id) {
        const res = await api.get('api/account/coachings', id)
        logger.log(res.data)
        AppState.coachings = res.data
    }

    async createCoaching(body) {
        const res = await api.post('api/account/coachings', body)
        logger.log(res.data)
        AppState.coachings.unshift(res.body)
    }

    async editCoaching(updatedCoaching) {
        const res = await api.put('api/account/coachings/' + updatedCoaching.id, updatedCoaching)
        logger.log(res.data)
        AppState.activeCoaching = new Coaching(res.data)
    }

    async removeCoaching(id) {
        const res = await api.delete('api/account/coachings/' + id)
        logger.log('Deleted')
        const found = AppState.coachings.findIndex(c => c.id == id)
        AppState.coachings.splice(found, 1)
        logger.log(AppState.coachings)
    }
}

export const coachingsService = new CoachingsService()