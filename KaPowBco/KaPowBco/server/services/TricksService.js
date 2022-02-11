import { BadRequest } from "@bcwdev/auth0provider/lib/Errors";
import { dbContext } from "../db/DbContext"

class TricksService {
    async getByCreatorId(id) {
        const myTricks = await dbContext.Tricks.find({ creatorId: id }).populate('creator', 'name picture')
        return myTricks
    }
    async getAll() {
        const tricks = await dbContext.Tricks.find().populate('creator', 'name picture')
        return tricks
    }

    async getById(id) {
        const trick = await dbContext.Tricks.findById(id).populate('creator', 'name picture')
        if (!trick) {
            throw new BadRequest('Invalid Trick')
        }
        return trick
    }

    async create(newTrick) {
        const createdTrick = await dbContext.Tricks.create(newTrick)
        await createdTrick.populate('creator', 'name picture')
        return createdTrick
    }

    async edit(updated, creatorId) {
        const original = await this.getById(updated.id)
        if (original.accountId.toString() !== creatorId) {
            throw new BadRequest('Unauthorized')
        }
        original.contentUrl = updated.contentUrl || original.contentUrl
        original.name = updated.name || original.name
        original.type = updated.type || original.type
        original.contentType = updated.contentType || original.contentType
        original.steps = updated.steps || original.steps
        original.difficulty = updated.difficulty || original.difficulty
        await original.save()
        return original
    }

    async remove(id, creatorId) {
        const original = await this.getById(id)
        if (original.creatorId.toString() !== creatorId) {
            throw new BadRequest('Unauthorized')
        }
        await dbContext.Tricks.findOneAndRemove({ _id: id, creatorId: creatorId })
    }
}

export const tricksService = new TricksService()