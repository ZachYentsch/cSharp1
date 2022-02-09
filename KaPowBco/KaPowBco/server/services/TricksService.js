import { BadRequest } from "@bcwdev/auth0provider/lib/Errors";
import { dbContext } from "../db/DbContext"

class TricksService {
    async getAll() {
        const pieces = await dbContext.Tricks.find().populate('creator', 'name', 'picture')
    }

}

export const tricksService = new TricksService()