export const state = () => ({
  products: [],
  categories: [],
  selectedCategoryId: 0,
});

export const mutations = {
  setProducts(state, content) {
    state.products = content;
  },
  setCategories(state, content) {
    state.categories = content;
  },
};

export const actions = {
  async getProducts({ state, commit }, payload) {
    const existingItems = state.products;
    const currentCategoryId = state.selectedCategoryId;
    if (existingItems.length > 0 && currentCategoryId === payload?.categoryId)
      return;
    const queryParams = {
      categoryId: payload?.categoryId,
    };

    const response = await this.$axios.$get('catalog', { params: queryParams });
    if (response.success) {
      commit('setProducts', response.data);
    }
  },
  async getCategories({ state, commit }) {
    const existingItems = state.categories;
    if (existingItems.length > 0) return;

    const response = await this.$axios.$get('catalog/categories');
    if (response.success) {
      commit('setCategories', response.data);
    }
  },
};
