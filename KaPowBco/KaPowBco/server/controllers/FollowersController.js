import { Auth0Provider } from "@bcwdev/auth0provider";
import BaseController from "../utils/BaseController"
import { followersService } from "../services/FollowersService";

export class FollowersController extends BaseController {
    constructor() {
        super("api/account/followers")
        this.router
            .use(Auth0Provider.getAuthorizedUserInfo)
            .post('', this.addFollower)
            .delete('/:id', this.remove)
    }

    async addFollower(req, res, next) {
        try {
            req.body.accountId = req.userInfo.id
            const addFollower = await followersService.addFollower(req.body)
            return res.send(addFollower)
        } catch (error) {
            next(error)
        }
    }

    async remove(req, res, next) {
        try {
            const deleteFollower = await followersService.removeFollower(req.params.id, req.userInfo.id)
            res.send(deleteFollower)
        } catch (error) {
            next(error)
        }
    }


}