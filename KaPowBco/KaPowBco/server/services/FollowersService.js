import { BadRequest } from "@bcwdev/auth0provider/lib/Errors";
import { dbContext } from "../db/DbContext"


class FollowersService {

    async getFollowing(userId) {
        const followers = await dbContext.Followers.find({ trainerId: userId }).populate('trainer', 'name picture')
        return followers
    }

    async getMyFollowers(accountId) {
        const followers = await dbContext.Followers.find({ accountId: accountId }).populate('learner', 'name picture')
        return followers
    }

    async addFollower(newFollower) {
        const addFollower = await dbContext.Followers.create(newFollower)
        await addFollower.populate('learner', 'name picture')
        return addFollower
    }

    async removeFollower(objectId, userId) {
        const foundFollower = await dbContext.Followers.findById(userId)
        if (foundFollower.learnerId.toString() !== userId) {
            throw new BadRequest('Cannot Delete')
        }
        await foundFollower.remove()
        return foundFollower
    }
}

export const followersService = new FollowersService()