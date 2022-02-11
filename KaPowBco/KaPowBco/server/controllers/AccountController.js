import { Auth0Provider } from '@bcwdev/auth0provider'
import { accountService } from '../services/AccountService'
import { followersService } from '../services/FollowersService'
import { tricksService } from '../services/TricksService'
import BaseController from '../utils/BaseController'

export class AccountController extends BaseController {
  constructor() {
    super('account')
    this.router
      .use(Auth0Provider.getAuthorizedUserInfo)
      .get('', this.getUserAccount)
      .get('/tricks', this.getTricksByCreatorId)
      .get('/following', this.getFollowing)
      .get('followers', this.getFollowers)
      .put('', this.updateAccount)
  }

  async getUserAccount(req, res, next) {
    try {
      const account = await accountService.getAccount(req.userInfo)
      res.send(account)
    } catch (error) {
      next(error)
    }
  }

  async getFollowing(req, res, next) {
    try {
      const following = await followersService.getFollowing(req.userInfo.id)
      return res.send(following)
    } catch (error) {
      next(error)
    }
  }

  async getFollowers(req, res, next) {
    try {
      const followers = await followersService.getMyFollowers(req.userInfo.id)
      return res.send(followers)
    } catch (error) {
      next(error)
    }
  }

  async updateAccount(req, res, next) {
    try {
      const account = await accountService.updateAccount(req.userInfo, req.body)
      res.send(account)
    } catch (error) {
      next(error)
    }
  }

  async getTricksByCreatorId(req, res, next) {
    try {
      const tricks = await tricksService.getByCreatorId(req.userInfo.id)
      res.send(tricks)
    } catch (error) {
      next(error)
    }
  }
}
