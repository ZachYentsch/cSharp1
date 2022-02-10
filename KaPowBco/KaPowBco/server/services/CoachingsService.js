import { BadRequest } from "@bcwdev/auth0provider/lib/Errors";
import { dbContext } from "../db/DbContext"

class CoachingsService {
    async getByAccount(userId) {
        const coachings = await dbContext.Coaching.find({ $or: [{ trainerId: userId }, { learnerId: userId }] })
            .populate('trainer', 'name picture')
            .populate('learner', 'name picture')
        return coachings
    }

    async getById(id, userId) {
        const coachings = await dbContext.Coaching.findOne({ _id: id, $or: [{ trainerId: userId }, { learnerId: userId }] })
            .populate('trainer', 'name picture')
            .populate('learner', 'name picture')
        if (!coachings) {
            throw new BadRequest('Invalid ID')
        }
        return coachings
    }

    async create(newCoaching) {
        const createdCoaching = await dbContext.Coaching.create(newCoaching)
        await createdCoaching.populate('trainer', 'name picture')
        await createdCoaching.populate('learner', 'name picture')
        return createdCoaching
    }

    async editCoaching(updated, userId) {
        const original = await this.getById(updated.id, userId)
        if (original.status.toString() !== 'denied') {
            throw new BadRequest('Cannot Edit. It is Denied')
        }
        if (original.trainerId.toString() == userId) {
            original.totalPrice = updated.totalPrice || original.totalPrice
            original.status = updated.status || original.status
            original.payment = updated.payment || original.payment
        } else {
            original.status = updated.status || original.status
            original.type = updated.type || original.type
            original.description = updated.description || original.description
        }
        await original.save()
        return original
    }

    async remove(id, userId) {
        const foundCoaching = await this.getById(id, userId)
        foundCoaching.status = 'canceled'
        await foundCoaching.save()
        return foundCoaching
    }
}

export const coachingsService = new CoachingsService()